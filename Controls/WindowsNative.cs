using System;
using System.Runtime.InteropServices;

namespace AxCommander.Controls {
    public class WindowsNative {
        public static bool MoveFileToRecycleBin( string path ) {
            SHFILEOPSTRUCT fileOp = new SHFILEOPSTRUCT {
                FileFunc = FileFunc.FO_DELETE,
                NamesFrom = $"{path}\0", // Строки NamesFrom, NameTo должны заканчиваться двумя '\0'. Один добавит p/invoke. В итоге получится два.
                NameTo = null,
                Flags = FILEOP_FLAGS.FOF_ALLOWUNDO | FILEOP_FLAGS.FOF_NOCONFIRMATION | FILEOP_FLAGS.FOF_SILENT
            };
            return SHFileOperation( ref fileOp ) == 0;
        }

        [DllImport( "shell32.dll", CharSet = CharSet.Unicode )]
        private static extern int SHFileOperation( ref SHFILEOPSTRUCT lpFileOp );

        [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Unicode )]
        private struct SHFILEOPSTRUCT {
            public IntPtr hwnd;
            public FileFunc FileFunc;

            [MarshalAs( UnmanagedType.LPWStr )]
            public string NamesFrom;

            [MarshalAs( UnmanagedType.LPWStr )]
            public string NameTo;

            public FILEOP_FLAGS Flags;

            [MarshalAs( UnmanagedType.Bool )]
            public bool fAnyOperationsAborted;

            public IntPtr hNameMappings;

            [MarshalAs( UnmanagedType.LPWStr )]
            public string lpszProgressTitle;
        }

        public enum FileFunc : uint {
            FO_MOVE = 0x1,
            FO_COPY = 0x2,
            FO_DELETE = 0x3,
            FO_RENAME = 0x4
        }

        [Flags]
        public enum FILEOP_FLAGS : ushort {
            FOF_MULTIDESTFILES = 0x1,
            FOF_CONFIRMMOUSE = 0x2,
            /// <summary>
            /// Don't create progress/report
            /// </summary>
            FOF_SILENT = 0x4,
            FOF_RENAMEONCOLLISION = 0x8,
            /// <summary>
            /// Don't prompt the user.
            /// </summary>
            FOF_NOCONFIRMATION = 0x10,
            /// <summary>
            /// Fill in SHFILEOPSTRUCT.hNameMappings.
            /// Must be freed using SHFreeNameMappings
            /// </summary>
            FOF_WANTMAPPINGHANDLE = 0x20,
            FOF_ALLOWUNDO = 0x40,
            /// <summary>
            /// On *.*, do only files
            /// </summary>
            FOF_FILESONLY = 0x80,
            /// <summary>
            /// Don't show names of files
            /// </summary>
            FOF_SIMPLEPROGRESS = 0x100,
            /// <summary>
            /// Don't confirm making any needed dirs
            /// </summary>
            FOF_NOCONFIRMMKDIR = 0x200,
            /// <summary>
            /// Don't put up error UI
            /// </summary>
            FOF_NOERRORUI = 0x400,
            /// <summary>
            /// Dont copy NT file Security Attributes
            /// </summary>
            FOF_NOCOPYSECURITYATTRIBS = 0x800,
            /// <summary>
            /// Don't recurse into directories.
            /// </summary>
            FOF_NORECURSION = 0x1000,
            /// <summary>
            /// Don't operate on connected elements.
            /// </summary>
            FOF_NO_CONNECTED_ELEMENTS = 0x2000,
            /// <summary>
            /// During delete operation,
            /// warn if nuking instead of recycling (partially overrides FOF_NOCONFIRMATION)
            /// </summary>
            FOF_WANTNUKEWARNING = 0x4000,
            /// <summary>
            /// Treat reparse points as objects, not containers
            /// </summary>
            FOF_NORECURSEREPARSE = 0x8000
        }
    }
}
