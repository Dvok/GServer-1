using GServer.Common;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GServer.Server.CommunicationProtocol
{
    public class MyRequestFilter : IReceiveFilter<MyRequestInfo>
    {
        // Example: $0140123456789|ABCD
        // [1Byte_prefix][3Byte_datagram_len_in_HEX][DATA]|[4Byte_CRC_HEX]
        private const string ProtocolHeaderStartKey = "$";
        private const int ProtocolHeaderKeyRepetitions = 1;
        private const int ProtocolDataLength = 3;
        private const int MaxBufferSize = 1024; // 1 килобайт = 1024 байт
        private readonly byte[] _inputBuffer;
        private readonly byte _protocolHeaderStartBinaryKey;
        private int _bufferLastOffset;

        public MyRequestFilter()
        {
            _inputBuffer = new byte[ MaxBufferSize ];
            _protocolHeaderStartBinaryKey = Encoding.ASCII.GetBytes( ProtocolHeaderStartKey )[ 0 ];
        }

        public MyRequestInfo Filter( byte[] readBuffer,
            int offset, int length,
            bool toBeCopied, out int rest )
        {
            // Copy to local buffer
            Array.Copy( readBuffer, offset, _inputBuffer, _bufferLastOffset, length );
            _bufferLastOffset += length;

            if ( _bufferLastOffset < ProtocolHeaderKeyRepetitions + ProtocolDataLength )
            {
                // Wait for full portion
                rest = 0;
                return null;
            }

            // Detect protocol header            
            int protocolHeaderStartIndex = Array.IndexOf(
                _inputBuffer,
                _protocolHeaderStartBinaryKey,
                0,
                ProtocolHeaderKeyRepetitions );

            if ( protocolHeaderStartIndex == -1 )
            {
                Reset();
                rest = 0;
                return null;
            }

            int commandLength = Convert.ToInt32( 
                Encoding.ASCII.GetString(
                    _inputBuffer,
                    ProtocolHeaderKeyRepetitions,
                    ProtocolDataLength 
                ) 
            );

            string CommandKey = Encoding.ASCII.GetString(
                _inputBuffer,
                ProtocolHeaderKeyRepetitions + ProtocolDataLength,
                commandLength 
            );

            byte[] guidBytes = Utils.SubArray<byte>( _inputBuffer, ProtocolHeaderKeyRepetitions + ProtocolDataLength + commandLength, 36 );
            string Guid = Encoding.ASCII.GetString( guidBytes );

            byte[] Object = Utils.SubArray<byte>( 
                _inputBuffer,
                ProtocolHeaderKeyRepetitions + ProtocolDataLength + commandLength + 36,
                _inputBuffer.Length - ( ProtocolHeaderKeyRepetitions + ProtocolDataLength + commandLength + 36 ) 
            );

            rest = 0;

            return new MyRequestInfo( CommandKey, Guid, Object );

        }

        public void Reset()
        {

        }

        public int LeftBufferSize
        {
            get { return 0; }
        }

        public IReceiveFilter<MyRequestInfo> NextReceiveFilter
        {
            get { return this; }
        }

        /// <summary>
        /// Gets the filter state.
        /// </summary>
        /// <value>
        /// The filter state.
        /// </value>
        public FilterState State { get; private set; }

    }
}
