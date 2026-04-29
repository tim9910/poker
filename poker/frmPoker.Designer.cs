namespace poker
{
    partial class frmPoker
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
            this.grpPoker = new System.Windows.Forms.GroupBox();
            this.btnDealCard = new System.Windows.Forms.Button();
            this.btnChangeCard = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.grpFunc = new System.Windows.Forms.GroupBox();
            this.grpDet = new System.Windows.Forms.GroupBox();
            this.btnDet = new System.Windows.Forms.Button();
            this.txtDet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAmt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.msgLabel = new System.Windows.Forms.Label();
            this.grpFunc.SuspendLayout();
            this.grpDet.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPoker
            // 
            this.grpPoker.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpPoker.Location = new System.Drawing.Point(18, 18);
            this.grpPoker.Margin = new System.Windows.Forms.Padding(4);
            this.grpPoker.Name = "grpPoker";
            this.grpPoker.Padding = new System.Windows.Forms.Padding(4);
            this.grpPoker.Size = new System.Drawing.Size(728, 240);
            this.grpPoker.TabIndex = 0;
            this.grpPoker.TabStop = false;
            this.grpPoker.Text = "牌桌";
            // 
            // btnDealCard
            // 
            this.btnDealCard.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDealCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDealCard.Enabled = false;
            this.btnDealCard.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnDealCard.FlatAppearance.BorderSize = 0;
            this.btnDealCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDealCard.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDealCard.Location = new System.Drawing.Point(6, 37);
            this.btnDealCard.Margin = new System.Windows.Forms.Padding(4);
            this.btnDealCard.Name = "btnDealCard";
            this.btnDealCard.Size = new System.Drawing.Size(117, 87);
            this.btnDealCard.TabIndex = 1;
            this.btnDealCard.Text = "發牌";
            this.btnDealCard.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnDealCard.UseVisualStyleBackColor = false;
            this.btnDealCard.Click += new System.EventHandler(this.btnDealCard_Click);
            // 
            // btnChangeCard
            // 
            this.btnChangeCard.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnChangeCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeCard.Enabled = false;
            this.btnChangeCard.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnChangeCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeCard.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnChangeCard.Location = new System.Drawing.Point(129, 37);
            this.btnChangeCard.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangeCard.Name = "btnChangeCard";
            this.btnChangeCard.Size = new System.Drawing.Size(117, 87);
            this.btnChangeCard.TabIndex = 2;
            this.btnChangeCard.Text = "換牌";
            this.btnChangeCard.UseVisualStyleBackColor = false;
            this.btnChangeCard.Click += new System.EventHandler(this.btnChangeCard_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.Enabled = false;
            this.btnCheck.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCheck.Location = new System.Drawing.Point(257, 37);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(117, 87);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "判斷牌型";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lblResult
            // 
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblResult.Location = new System.Drawing.Point(383, 46);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(326, 68);
            this.lblResult.TabIndex = 4;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpFunc
            // 
            this.grpFunc.Controls.Add(this.btnDealCard);
            this.grpFunc.Controls.Add(this.lblResult);
            this.grpFunc.Controls.Add(this.btnChangeCard);
            this.grpFunc.Controls.Add(this.btnCheck);
            this.grpFunc.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpFunc.Location = new System.Drawing.Point(18, 398);
            this.grpFunc.Name = "grpFunc";
            this.grpFunc.Size = new System.Drawing.Size(727, 133);
            this.grpFunc.TabIndex = 5;
            this.grpFunc.TabStop = false;
            this.grpFunc.Text = "功能";
            // 
            // grpDet
            // 
            this.grpDet.Controls.Add(this.btnDet);
            this.grpDet.Controls.Add(this.txtDet);
            this.grpDet.Controls.Add(this.label4);
            this.grpDet.Controls.Add(this.lblAmt);
            this.grpDet.Controls.Add(this.label1);
            this.grpDet.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.grpDet.Location = new System.Drawing.Point(18, 281);
            this.grpDet.Name = "grpDet";
            this.grpDet.Size = new System.Drawing.Size(728, 101);
            this.grpDet.TabIndex = 6;
            this.grpDet.TabStop = false;
            this.grpDet.Text = "下注";
            // 
            // btnDet
            // 
            this.btnDet.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDet.Enabled = false;
            this.btnDet.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnDet.Location = new System.Drawing.Point(593, 25);
            this.btnDet.Name = "btnDet";
            this.btnDet.Size = new System.Drawing.Size(129, 70);
            this.btnDet.TabIndex = 4;
            this.btnDet.Text = "押注";
            this.btnDet.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btnDet.UseVisualStyleBackColor = false;
            this.btnDet.Click += new System.EventHandler(this.btnDet_Click);
            // 
            // txtDet
            // 
            this.txtDet.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDet.Location = new System.Drawing.Point(429, 41);
            this.txtDet.Name = "txtDet";
            this.txtDet.Size = new System.Drawing.Size(158, 34);
            this.txtDet.TabIndex = 3;
            this.txtDet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "押注金額";
            // 
            // lblAmt
            // 
            this.lblAmt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAmt.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAmt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAmt.Location = new System.Drawing.Point(113, 41);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(184, 43);
            this.lblAmt.TabIndex = 1;
            this.lblAmt.Text = " ";
            this.lblAmt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "總資金";
            // 
            // msgLabel
            // 
            this.msgLabel.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.msgLabel.ForeColor = System.Drawing.Color.Red;
            this.msgLabel.Location = new System.Drawing.Point(25, 550);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(720, 39);
            this.msgLabel.TabIndex = 7;
            this.msgLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPoker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 601);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.grpDet);
            this.Controls.Add(this.grpFunc);
            this.Controls.Add(this.grpPoker);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPoker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPoker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPoker_FormClosing);
            this.Load += new System.EventHandler(this.frmPoker_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmPoker_KeyPress);
            this.grpFunc.ResumeLayout(false);
            this.grpDet.ResumeLayout(false);
            this.grpDet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPoker;
        private System.Windows.Forms.Button btnDealCard;
        private System.Windows.Forms.Button btnChangeCard;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.GroupBox grpFunc;
        private System.Windows.Forms.GroupBox grpDet;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblAmt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDet;
        private System.Windows.Forms.Label msgLabel;
        private System.Windows.Forms.Button btnDet;
    }
}