namespace CameraWindowsForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cameraViewer1 = new LibOCR.CameraViewer();
            this.bntConfigVLC = new System.Windows.Forms.Button();
            this.btnStartCamera = new System.Windows.Forms.Button();
            this.btnCaprture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cameraViewer1
            // 
            this.cameraViewer1.Location = new System.Drawing.Point(312, 179);
            this.cameraViewer1.Name = "cameraViewer1";
            this.cameraViewer1.Size = new System.Drawing.Size(293, 212);
            this.cameraViewer1.TabIndex = 0;
            // 
            // bntConfigVLC
            // 
            this.bntConfigVLC.Location = new System.Drawing.Point(110, 51);
            this.bntConfigVLC.Name = "bntConfigVLC";
            this.bntConfigVLC.Size = new System.Drawing.Size(75, 23);
            this.bntConfigVLC.TabIndex = 1;
            this.bntConfigVLC.Text = "ConfigVLC";
            this.bntConfigVLC.UseVisualStyleBackColor = true;
            this.bntConfigVLC.Click += new System.EventHandler(this.bntConfigVLC_Click);
            // 
            // btnStartCamera
            // 
            this.btnStartCamera.Location = new System.Drawing.Point(303, 51);
            this.btnStartCamera.Name = "btnStartCamera";
            this.btnStartCamera.Size = new System.Drawing.Size(75, 23);
            this.btnStartCamera.TabIndex = 2;
            this.btnStartCamera.Text = "StartCamera";
            this.btnStartCamera.UseVisualStyleBackColor = true;
            this.btnStartCamera.Click += new System.EventHandler(this.btnStartCamera_Click);
            // 
            // btnCaprture
            // 
            this.btnCaprture.Location = new System.Drawing.Point(504, 51);
            this.btnCaprture.Name = "btnCaprture";
            this.btnCaprture.Size = new System.Drawing.Size(75, 23);
            this.btnCaprture.TabIndex = 3;
            this.btnCaprture.Text = "Capture";
            this.btnCaprture.UseVisualStyleBackColor = true;
            this.btnCaprture.Click += new System.EventHandler(this.btnCaprture_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCaprture);
            this.Controls.Add(this.btnStartCamera);
            this.Controls.Add(this.bntConfigVLC);
            this.Controls.Add(this.cameraViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private LibOCR.CameraViewer cameraViewer1;
        private System.Windows.Forms.Button bntConfigVLC;
        private System.Windows.Forms.Button btnStartCamera;
        private System.Windows.Forms.Button btnCaprture;
    }
}

