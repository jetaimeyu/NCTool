﻿namespace NCTool
{
    partial class Login
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
            this.lbVersion = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chbIsRemember = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbVersion.Location = new System.Drawing.Point(157, 108);
            this.lbVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(59, 12);
            this.lbVersion.TabIndex = 30;
            this.lbVersion.Text = "V 1.0.1.0";
            // 
            // tbUser
            // 
            this.tbUser.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbUser.Location = new System.Drawing.Point(92, 159);
            this.tbUser.Margin = new System.Windows.Forms.Padding(4);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(185, 30);
            this.tbUser.TabIndex = 22;
            this.tbUser.Text = "admin@80037366";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(282, 159);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 28);
            this.btnDelete.TabIndex = 26;
            this.btnDelete.Text = "X";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(111, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 38);
            this.label3.TabIndex = 29;
            this.label3.Text = "耐驰工具";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chbIsRemember
            // 
            this.chbIsRemember.AutoSize = true;
            this.chbIsRemember.Location = new System.Drawing.Point(242, 248);
            this.chbIsRemember.Margin = new System.Windows.Forms.Padding(4);
            this.chbIsRemember.Name = "chbIsRemember";
            this.chbIsRemember.Size = new System.Drawing.Size(72, 16);
            this.chbIsRemember.TabIndex = 24;
            this.chbIsRemember.Text = "记住密码";
            this.chbIsRemember.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(118, 282);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(140, 40);
            this.btnLogin.TabIndex = 25;
            this.btnLogin.Text = "登  录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassWord.Location = new System.Drawing.Point(92, 210);
            this.txtPassWord.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(222, 30);
            this.txtPassWord.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 217);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 165);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "账号：";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 376);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chbIsRemember);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbIsRemember;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}