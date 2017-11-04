/******************************************************************************
 *
 * Filename: Pico.cs
 * 
 * Description:
 *   This is a program that demonstrates how to use the
 *   ps2000 driver API functions using .NET
 *   
 * Supported PicoScope models:
 *
 *		PicoScope 2104 & 2105 
 *		PicoScope 2202 & 2203 
 *		PicoScope 2204 & 2204A 
 *		PicoScope 2205 & 2205A
 *
 * Examples:
 *    Collect a block of samples immediately
 *    Collect a block of samples when a trigger event occurs
 *    Collect data in fast/compatible streaming mode without trigger
 *    Collect data in fast/compatible streaming mode with trigger
 *    
 * Copyright (C) 2014 - 2017 Pico Technology Ltd. See LICENSE file for terms.  
 * 
 * Adjustments made to code by Malfy Das to fit PM2gui.
 *
 *****************************************************************************/

using System;
using System.IO;
using System.Threading;

using PicoPinnedArray;
using PS2000Imports;

namespace PM2gui
{
    class Pico
    {
        public struct ChannelSettings
        {
            public short DCcoupled;
            public Imports.Range range;
            public short enabled;
            
        }

        public class Pwq
        {
            public Imports.PwqConditions[] conditions;
            public short nConditions;
            public Imports.ThresholdDirection direction;
            public uint lower;
            public uint upper;
            public Imports.PulseWidthType type;

            public Pwq(Imports.PwqConditions[] conditions,
                short nConditions,
                Imports.ThresholdDirection direction,
                uint lower, uint upper,
                Imports.PulseWidthType type)
            {
                this.conditions = conditions;
                this.nConditions = nConditions;
                this.direction = direction;
                this.lower = lower;
                this.upper = upper;
                this.type = type;
            }
        }
        
        public class PicoInterfacer
        {
            public readonly short _handle;
            public const int BUFFER_SIZE = 1024;
            public const int SINGLE_SCOPE = 1;
            public const int DUAL_SCOPE = 2;
            public const int MAX_CHANNELS = 4;
            public const int COMPATIBLE_STREAMING_MAX_SAMPLES = 60000;

            static public short timebase = 1;
            static public short oversample = 1;
            //bool _hasFastStreaming = false;

            //uint _totalSampleCount = 0;
            //uint _nValues = 0;
            //bool _autoStop;
            //short _trig;
            //uint _trigAt;
            //bool _appBufferFull;
            public short[][] _appBuffer = new short[DUAL_SCOPE][];
            //private uint _OverViewBufferSize = 150000;
            //private uint _MaxSamples = 1000000;

            static public ushort[] inputRanges = { 10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000 };
            //private ChannelSettings[] channelSettings;

            private int channelCount = DUAL_SCOPE; //DUAL_SCOPE;
            //private Imports.Range _firstRange;
            //private Imports.Range _lastRange;
            PinnedArray<short>[] pinned = new PinnedArray<short>[4];
            //private string BlockFile = "block.txt";
            //private string StreamFile = "stream.txt";

            /****************************************************************************
             * SetDefaults - restore default settings
             ****************************************************************************/
            public void SetDefaults(short handle, ChannelSettings[] channelSettings)
            {
                for (int i = 0; i < channelCount; i++) // set channels to most recent settings
                {
                    Imports.SetChannel(handle, (Imports.Channel)(i),
                                       channelSettings[i].enabled,
                                       channelSettings[i].DCcoupled,
                                       channelSettings[i].range);
                }

            }


            /****************************************************************************
            *  SetTrigger
            *  this function sets all the required trigger parameters, and calls the 
            *  triggering functions
            ****************************************************************************/
            public short SetTrigger(Imports.TriggerChannelProperties[] channelProperties,
                            short nChannelProperties,
                            Imports.TriggerConditions[] triggerConditions,
                            short nTriggerConditions,
                            Imports.ThresholdDirection[] directions,
                            Pwq pwq,
                            uint delay,
                            int autoTriggerMs)
            {
                short status = 0;

                status = Imports.SetTriggerChannelProperties(_handle, channelProperties, nChannelProperties, autoTriggerMs);

                if (status == 0)
                {
                    return status;
                }

                status = Imports.SetTriggerChannelConditions(_handle, triggerConditions, nTriggerConditions);

                if (status == 0)
                {
                    return status;
                }

                if (directions == null)
                {
                    directions = new Imports.ThresholdDirection[] { Imports.ThresholdDirection.None,
                                    Imports.ThresholdDirection.None, Imports.ThresholdDirection.None, Imports.ThresholdDirection.None,
                                    Imports.ThresholdDirection.None, Imports.ThresholdDirection.None};

                }


                status = Imports.SetTriggerChannelDirections(_handle,
                                                                  directions[(int)Imports.Channel.ChannelA],
                                                                  directions[(int)Imports.Channel.ChannelB],
                                                                  directions[(int)Imports.Channel.ChannelC],
                                                                  directions[(int)Imports.Channel.ChannelD],
                                                                  directions[(int)Imports.Channel.External]);

                if (status == 0)
                {
                    return status;
                }

                status = Imports.SetTriggerDelay(_handle, delay, 0);

                if (status == 0)
                {
                    return status;
                }

                if (pwq == null)
                {
                    pwq = new Pwq(null, 0, Imports.ThresholdDirection.None, 0, 0, Imports.PulseWidthType.None);
                }

                status = Imports.SetPulseWidthQualifier(_handle, pwq.conditions,
                                                        pwq.nConditions, pwq.direction,
                                                        pwq.lower, pwq.upper, pwq.type);


                return status;
            }


            /****************************************************************************
             * Select timebase, set oversample to on and time units as nano seconds
             ****************************************************************************/
            public void SetTimebase(short handle)
            {
                int timeInterval;
                int maxSamples;
                short timeunit;
                bool valid = false;
                short status = 0;
                short maxTimebaseIndex = 0; // Use this to place an upper bound on the timebase index selected

                Console.WriteLine("Available timebases indices and sampling intervals (nanoseconds):\n");

                for (short i = 0; i < Imports.PS2200_MAX_TIMEBASE; i++)
                {
                    status = Imports.GetTimebase(_handle, i, BUFFER_SIZE, out timeInterval, out timeunit, oversample, out maxSamples);

                    if (status == 1)
                    {
                        Console.WriteLine("{0,2}: {1} ns", i, timeInterval);
                        maxTimebaseIndex = i;
                    }
                }

                do
                {
                    Console.WriteLine("\nSpecify timebase index:");

                    try
                    {
                        timebase = short.Parse(Console.ReadLine());

                        if (timebase < 0 || timebase > maxTimebaseIndex)
                        {
                            valid = false;
                        }
                        else
                        {
                            valid = true;
                        }

                    }
                    catch (FormatException)
                    {
                        valid = false;
                        Console.WriteLine("\nEnter numeric values only");
                    }

                } while (!valid);

                status = 0;

                do
                {
                    status = Imports.GetTimebase(handle, timebase, BUFFER_SIZE, out timeInterval, out timeunit, oversample, out maxSamples);

                    if (status == 0)
                    {
                        Console.WriteLine("Selected timebase {0} could not be used", timebase);
                        timebase++;
                    }
                }
                while (status == 0);

                Console.WriteLine("Timebase {0} - {1} ns", timebase, timeInterval);
                oversample = 1;
            }


            /****************************************************************************
             * Run - show menu and call user selected options
             ****************************************************************************/

            public PicoInterfacer(short handle)
            {
                _handle = handle;
            }


        }
    }
}
