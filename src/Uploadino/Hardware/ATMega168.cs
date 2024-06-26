﻿using System.Collections.Generic;
using Uploadino.Hardware.Memory;

namespace Uploadino.Hardware
{
    internal class AtMega168 : Mcu
    {
        public override byte DeviceCode => 0x86;

        public override byte DeviceRevision => 0;

        public override byte ProgType => 0;

        public override byte ParallelMode => 1;

        public override byte Polling => 1;

        public override byte SelfTimed => 1;

        public override byte LockBytes => 1;

        public override byte FuseBytes => 3;

        public override byte Timeout => 200;

        public override byte StabDelay => 100;

        public override byte CmdExeDelay => 25;

        public override byte SynchLoops => 32;

        public override byte ByteDelay => 0;

        public override byte PollIndex => 3;

        public override byte PollValue => 0x53;

        public override string DeviceSignature => "1E-94-06";

        public override IDictionary<Command, byte[]> CommandBytes => 
            new Dictionary<Command, byte[]>();

        public override IList<IMemory> Memory => new List<IMemory>
        {
            new FlashMemory
            {
                Size = 16 * 1024,
                PageSize = 128,
                PollVal1 = 0xff,
                PollVal2 = 0xff
            },
            new EepromMemory
            {
                Size = 512,
                PollVal1 = 0xff,
                PollVal2 = 0xff
            }
        };
    }
}