namespace AxCommander.Controls {
    partial class PerformanceControl {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.labelCpuValue = new System.Windows.Forms.Label();
            this.labelMemoryValue = new System.Windows.Forms.Label();
            this.labelMemoryIcon = new System.Windows.Forms.Label();
            this.labelCpuIcon = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCpuValue
            // 
            this.labelCpuValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCpuValue.Location = new System.Drawing.Point( 25, 4 );
            this.labelCpuValue.Name = "labelCpuValue";
            this.labelCpuValue.Size = new System.Drawing.Size( 52, 16 );
            this.labelCpuValue.TabIndex = 4;
            this.labelCpuValue.Text = "100.00%";
            // 
            // labelMemoryValue
            // 
            this.labelMemoryValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMemoryValue.Location = new System.Drawing.Point( 105, 4 );
            this.labelMemoryValue.Name = "labelMemoryValue";
            this.labelMemoryValue.Size = new System.Drawing.Size( 81, 16 );
            this.labelMemoryValue.TabIndex = 4;
            this.labelMemoryValue.Text = "100.00%";
            // 
            // labelMemoryIcon
            // 
            this.labelMemoryIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMemoryIcon.Image = global::Controls.Properties.Resources.memory;
            this.labelMemoryIcon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelMemoryIcon.Location = new System.Drawing.Point( 83, 0 );
            this.labelMemoryIcon.Name = "labelMemoryIcon";
            this.labelMemoryIcon.Size = new System.Drawing.Size( 25, 20 );
            this.labelMemoryIcon.TabIndex = 3;
            this.labelMemoryIcon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCpuIcon
            // 
            this.labelCpuIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCpuIcon.Image = global::Controls.Properties.Resources.cpu;
            this.labelCpuIcon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCpuIcon.Location = new System.Drawing.Point( 3, 0 );
            this.labelCpuIcon.Name = "labelCpuIcon";
            this.labelCpuIcon.Size = new System.Drawing.Size( 25, 20 );
            this.labelCpuIcon.TabIndex = 3;
            this.labelCpuIcon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PerformanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.labelMemoryValue );
            this.Controls.Add( this.labelCpuValue );
            this.Controls.Add( this.labelMemoryIcon );
            this.Controls.Add( this.labelCpuIcon );
            this.Name = "PerformanceControl";
            this.Size = new System.Drawing.Size( 316, 20 );
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Label labelCpuValue;
        private System.Windows.Forms.Label labelCpuIcon;
        private System.Windows.Forms.Label labelMemoryIcon;
        private System.Windows.Forms.Label labelMemoryValue;
    }
}
