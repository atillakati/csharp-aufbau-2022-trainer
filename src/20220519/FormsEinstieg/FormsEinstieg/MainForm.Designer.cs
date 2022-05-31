using System.Windows.Forms;

namespace FormsEinstieg
{
    partial class MainForm
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
            this.btt_accept = new System.Windows.Forms.Button();
            this.btt_cancel = new System.Windows.Forms.Button();
            this.lbl_header = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btt_accept
            // 
            this.btt_accept.Location = new System.Drawing.Point(269, 189);
            this.btt_accept.Name = "btt_accept";
            this.btt_accept.Size = new System.Drawing.Size(91, 23);
            this.btt_accept.TabIndex = 0;
            this.btt_accept.Text = "Übernehmen";
            this.btt_accept.UseVisualStyleBackColor = true;
            this.btt_accept.Click += new System.EventHandler(this.btt_accept_Click);
            // 
            // btt_cancel
            // 
            this.btt_cancel.Location = new System.Drawing.Point(188, 189);
            this.btt_cancel.Name = "btt_cancel";
            this.btt_cancel.Size = new System.Drawing.Size(75, 23);
            this.btt_cancel.TabIndex = 1;
            this.btt_cancel.Text = "Abbruch";
            this.btt_cancel.UseVisualStyleBackColor = true;
            this.btt_cancel.Click += new System.EventHandler(this.btt_cancel_Click);
            // 
            // lbl_header
            // 
            this.lbl_header.AutoSize = true;
            this.lbl_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_header.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_header.Location = new System.Drawing.Point(31, 27);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(267, 24);
            this.lbl_header.TabIndex = 2;
            this.lbl_header.Text = "Hier erscheint Ihre Eingabe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name: ";
            // 
            // txt_input
            // 
            this.txt_input.Location = new System.Drawing.Point(78, 87);
            this.txt_input.Name = "txt_input";
            this.txt_input.Size = new System.Drawing.Size(282, 20);
            this.txt_input.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 224);
            this.Controls.Add(this.txt_input);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_header);
            this.Controls.Add(this.btt_cancel);
            this.Controls.Add(this.btt_accept);
            this.MinimumSize = new System.Drawing.Size(388, 263);
            this.Name = "MainForm";
            this.Text = "Grundlagen Forms Applikation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btt_accept;
        private System.Windows.Forms.Button btt_cancel;
        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_input;
    }
}

