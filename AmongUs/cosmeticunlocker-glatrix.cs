using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Globalization;

namespace AmongUsHack
{
    class PatchCosmetics
    {
        private const string SIGNATURE = "74 04 B0 01 5D C3 56 8B 70 ?? 57";
        private static string[] FUNCS = { "GetUnlockedHats()", "GetUnlockedNamePlates()", "GetUnlockedPets()", "GetUnlockedSkins()", "GetUnlockedVisors()" };
        public static int patched = 0;


        /// <summary>
        /// Patches all cosmetics. (Should return 5)
        /// </summary>
        /// <returns>the number of functions patched.</returns>
        public static void Patch()
        {
            Process proc = Process.GetProcessesByName("Among Us")[0];
            ProcessModule module = GetModuleByName(proc, "GameAssembly");
            byte[] buffer = new byte[module.ModuleMemorySize];
            int bytesread = 0;
            IntPtr handle = OpenProcess(PROCESS_ALL_ACCESS, false, proc.Id);
            ReadProcessMemory(proc.Handle, module.BaseAddress, buffer, buffer.Length, ref bytesread); // might require openprocess, idk 
            string signature = SIGNATURE;
            var addy = sigscan(signature, module);
            var OLD_COL = System.Console.ForegroundColor;
            if (addy.Count != 5)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"[P@TCH3R] ERROR => Functions not found. ~ [{addy.Count}]");
            }
            else
            {
                foreach (var a in addy)
                {
                    byte[] write = new byte[2] { 0x90, 0x90 };
                    int w = 0;
                    WriteProcessMemory((int)handle, (int)IntPtr.Add(module.BaseAddress, (int)a), write, write.Length, ref w);

                    System.Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine($"[P@TCH3R] Patched: {FUNCS[patched]}");
                    patched++;
                }
                System.Console.WriteLine($"[P@TCH3R] ALL COSMETICS UNLOCKED");
            }
            System.Console.ForegroundColor = OLD_COL;
            int[] transformarray(string sig)
            {
                var bytes = sig.Split(' ');
                int[] intlist = new int[bytes.Length];

                for (int i = 0; i < intlist.Length; i++)
                {
                    if (bytes[i] == "??")
                        intlist[i] = -1;
                    else
                        intlist[i] = int.Parse(bytes[i], NumberStyles.HexNumber);
                }
                return intlist;
            }

            List<IntPtr> sigscan(string sig, ProcessModule m)
            {
                var intlist = transformarray(sig);
                var results = new List<IntPtr>();

                for (int a = 0; a < buffer.Length; a++)
                {
                    for (int b = 0; b < intlist.Length; b++)
                    {
                        if (intlist[b] != -1 && intlist[b] != buffer[a + b])
                            break;
                        if (b + 1 == intlist.Length)
                        {
                            var result = new IntPtr(a);
                            results.Add(result);
                        }
                    }
                }
                return results;
            }
        }

        [DllImport("kernel32.dll")] static extern bool ReadProcessMemory(IntPtr handle, IntPtr addy, byte[] buffer, int size, ref int bytesRead);
        [DllImport("kernel32.dll")] static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        [DllImport("kernel32.dll", SetLastError = true)] static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        private static ProcessModule GetModuleByName(Process p, string name)
        {
            foreach (ProcessModule mod in p.Modules)
            {
                if (mod.ModuleName.ToLower() == name.ToLower() || mod.ModuleName.ToLower() == name.ToLower() + ".dll")
                {
                    return mod;
                }
            }
            return null;
        }
    }
}