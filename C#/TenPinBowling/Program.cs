using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TenPinBowling
{
    class Program
    {
        const string StandardFramePattern = "(((X)|[0-9]{2}|([0-9]/)) ){9}";
        const string FinalFramePattern = "([0-9]{2}|(X(([0-9]([0-9]|/))|(X[0-9X])))|([0-9]/[0-9X]))";
        const int QuantityOfPins = 10;
        const int StandardFrameLength = 2;

        static void Main(string[] args)
        {
            Console.WriteLine(BowlingScore("11 11 11 11 11 11 11 11 11 11"));
            // 20 = 20 + 154
        }
        public static int BowlingScore(string frames)
        {
            IEnumerable<int> frameScores = PinsToScores(new List<int>(StringToPins(frames)));
            return frameScores.Sum();
        }

        private static IEnumerable<int> PinsToScores(List<int> pins)
        {
            const int sizeOfFinalFrame = (pins.ElementAt(pins.Count)
            for (int index = 0; index < (Frames-; index += StandardFrameLength)
            {
                if (index + StandardFrameLength >= pins.Count) yield break;

                // Not a strike or a spare
                if (pins[index] + pins[index+1] < QuantityOfPins)
                {
                    yield return pins[index] + pins[index + 1];
                    continue;
                }

                // If Strike or Spare
                yield return pins[index] + pins[index + 1] + pins[index + 2];

                // If Strike
                if (pins[index] == QuantityOfPins) index--;
            }

            for (int)
        }

        private static IEnumerable<int> StringToPins(string frames)
        {
            if (Regex.IsMatch(frames,
                "/^(((X)|[0-9]{2}|([0-9]/)) ){9}([0-9]{2}|(X(([0-9]([0-9]|/))|(X[0-9X])))|([0-9]/[0-9X]))$/"))
                throw new ArgumentException("Incorrect Scoresheet, check that frames have valid quantity of bowls");
            string[] framesSplit = frames.Split(" ");
            // Process standard frames
            for (int index = 0; index < 9; index++)
            {
                if (!IsValidStandardFrame(framesSplit[index]))
                    throw new ArgumentException(String.Format("Frame #{0} ({1}) invalid", index, framesSplit[index]));
                if (framesSplit[index].Equals("X")) yield return 10;
                else
                {
                    yield return framesSplit[index][0] - '0';
                    if (framesSplit[index][1] == '/')
                        yield return 10 - (framesSplit[index][0] - '0');
                    else yield return framesSplit[index][1] - '0';
                }
            }
            // Process final frame
            if (!IsValidFinalFrame(framesSplit[9]))
                throw new ArgumentException(String.Format("Frame #9 ({0}) invalid", framesSplit[9]));
            for (int charIndex = 0; charIndex < framesSplit[9].Length; charIndex++)
            {
                if (framesSplit[9][charIndex] == 'X') yield return 10;
                else if (framesSplit[9][charIndex] == '/') yield return 10 - (framesSplit[9][charIndex - 1] - '0');
                else yield return framesSplit[9][charIndex] - '0';
            }
        }

        private static bool IsValidStandardFrame(string frame)
        {
            if (frame.Length == 2)
            {
                if (frame[1] != '/')
                {
                    return IsValidNonTenFrame(frame);
                }
            }
            return true;
        }

        private static bool IsValidFinalFrame(string frame)
        {
            if (frame.Length == 2)
            {
                return IsValidNonTenFrame(frame);
            }
            else if (frame[0] == 'X')
            {
                if (frame[1] == 'X') return true;  // XX#
                else if (frame[2] == '/') return true; // X#/
                else return IsValidNonTenFrame(frame); // X##
            }
            return true;
        }

        private static bool IsValidNonTenFrame(string frame)
        {
            return (frame[1] + frame[0] - 2 * '0' < 10);
        }
    }
}
