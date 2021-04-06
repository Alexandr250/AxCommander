using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace AxCommander.Controls {
    public partial class PerformanceControl : UserControl {
        private System.Threading.Timer _timer;

        PerformanceCounter _cpucounter;
        PerformanceCounter _memcounter;

        public PerformanceControl() {
            InitializeComponent();
            _cpucounter = new PerformanceCounter( "Processor", "% Processor Time", "_Total" );
            _memcounter = new PerformanceCounter( "Memory", "% Committed Bytes In Use" );

            _timer = new System.Threading.Timer( TimerAction, null, 1000, 1000 );

        }

        private void TimerAction( object state ) {
            labelCpuValue.Invoke( new Action( () => labelCpuValue.Text = string.Format( "{0:0.##}%", _cpucounter.NextValue() ) ) );
            labelMemoryValue.Invoke( new Action( () => labelMemoryValue.Text = _memcounter.NextValue().ToString() ) );            
        }        
    }
}
