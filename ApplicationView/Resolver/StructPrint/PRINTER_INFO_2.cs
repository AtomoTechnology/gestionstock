using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.Resolver.StructPrint
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct PRINTER_INFO_2
    {
        /// <summary>
        /// This member MUST be a non-NULL pointer to a string that MUST specify the name of the server that hosts the printer. For rules governing server names, see section 2.2.4.16.
        /// summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pServerName;
        /// <summary>
        /// This member MUST be a non-NULL pointer to a string that MUST specify the name of a printer. For rules governing printer names, see section 2.2.4.14.
        /// summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pPrinterName;
        /// <summary>
        /// This member is an optional pointer to a string that specifies the share name for the printer. This string MUST be ignored unless the Attributes member contains the PRINTER_ATTRIBUTED_SHARED flag. For rules governing path names, see section 2.2.4.9.
        /// summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pShareName;
        /// <summary>
        /// This member is a pointer to a string that specifies the port(s) used to transmit data to a printer. For rules governing port names, see section 2.2.4.10.
        /// summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pPortName;
        /// <summary>
        ///  This member is a pointer to a string that specifies the name of the printer driver. For rules governing printer driver names, see section 2.2.4.3.
        /// summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pDriverName;
        /// <summary>
        ///  This member is an optional pointer to a string that MUST specify additional information about the printer.<18>
        /// summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pComment;
        /// <summary>
        /// This member is an optional pointer to a string that specifies the location of the printer.
        /// summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pLocation;
        /// <summary>
        /// This member is an optional pointer to a truncated DEVMODE structure (section 2.2.1.1.1), and MUST be ignored on receipt. Actual DEVMODE data is passed to a method via a custom-marshaled _DEVMODE structure (section 2.2.2.1) in a DEVMODE_CONTAINER (section 2.2.1.2.1).
        /// summary>
        public IntPtr pDevMode;
        /// <summary>
        ///  This member is an optional pointer to a string that specifies the name of a file whose contents are used to create a separator page. This page is used to separate print jobs sent to the printer. For rules governing path names, see section 2.2.4.9.
        /// summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pSepFile;
        /// <summary>
        /// This member is an optional pointer to a string that specifies the name of the print processor used by the printer. For rules governing print processor names, see section 2.2.4.11.
        /// summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pPrintProcessor;
        /// <summary>
        /// This member is an optional pointer to a string that specifies the default data format used to record print jobs on the printer. For rules governing data type names, see section 2.2.4.2.
        /// summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pDatatype;
        /// <summary>
        /// his member is an optional pointer to a string that specifies the default print processor parameters.
        /// summary>
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pParameters;
        /// <summary>
        /// This member is an optional pointer to a SECURITY_DESCRIPTOR structure ([MS-DTYP] section 2.4.6), and MUST be ignored on receipt. Actual SECURITY_DESCRIPTOR data is passed to a method via a self-relative SECURITY_DESCRIPTOR structure in a SECURITY_CONTAINER (section 2.2.1.2.13).
        /// summary>
        public IntPtr pSecurityDescriptor;

        public uint Attributes;
        /// <summary>
        ///  The value of this member specifies a priority value that the spooler uses to route each print job. The value of this member MUST be from 0 through 99, inclusive.
        /// summary>
        public uint Priority;
        /// <summary>
        /// The value of this member specifies the default priority value assigned to each print job. The value of this member MUST be from 0 through 99, inclusive.
        /// summary>
        public uint DefaultPriority;
        /// <summary>
        /// The value of this member specifies the earliest time that a job can be printed. The time is expressed as the number of minutes after 12:00 AM GMT within a 24-hour boundary.
        /// summary>
        public uint StartTime;
        /// <summary>
        /// The value of this member specifies the latest time that a job can be printed. The time is expressed as the number of minutes after 12:00 AM GMT within a 24-hour boundary
        /// summary>
        public uint UntilTime;
        /// <summary>
        /// This member specifies the printer status. It is the result of a bitwise OR of zero or more printer status values (section 2.2.3.12).
        /// summary>
        public uint Status;
        /// <summary>
        ///  The value of this member specifies the number of print jobs that have been queued for the printer
        /// summary>
        public uint cJobs;
        /// <summary>
        ///  The value of this member specifies the average pages per minute that have been printed on the printer.
        /// summary>
        public uint AveragePPM;
    }
}
