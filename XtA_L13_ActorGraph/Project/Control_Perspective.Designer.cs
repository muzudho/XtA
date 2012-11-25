namespace Xenon.Aims.ActorGraph
{
    partial class Control_Perspective
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            Xenon.Aims.ActorGraph.PainterImpl painterImpl1 = new Xenon.Aims.ActorGraph.PainterImpl();
            this.control_Note1 = new Xenon.Aims.ActorGraph.Control_Note();
            this.control_Toolbox1 = new Xenon.Aims.ActorGraph.Control_Toolbox();
            this.SuspendLayout();
            // 
            // control_Note1
            // 
            this.control_Note1.AllowDrop = true;
            this.control_Note1.BackColor = System.Drawing.Color.White;
            this.control_Note1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.control_Note1.Location = new System.Drawing.Point(30, 105);
            this.control_Note1.Margin = new System.Windows.Forms.Padding(5);
            this.control_Note1.Name = "control_Note1";
            this.control_Note1.Painter = painterImpl1;
            this.control_Note1.Size = new System.Drawing.Size(377, 279);
            this.control_Note1.TabIndex = 1;
            // 
            // control_Toolbox1
            // 
            this.control_Toolbox1.BackColor = System.Drawing.Color.Tan;
            this.control_Toolbox1.Location = new System.Drawing.Point(39, 26);
            this.control_Toolbox1.Name = "control_Toolbox1";
            this.control_Toolbox1.Size = new System.Drawing.Size(368, 38);
            this.control_Toolbox1.TabIndex = 0;
            // 
            // Control_Perspective
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.control_Note1);
            this.Controls.Add(this.control_Toolbox1);
            this.Name = "Control_Perspective";
            this.Size = new System.Drawing.Size(447, 413);
            this.Load += new System.EventHandler(this.Control_Canvas_Load);
            this.Resize += new System.EventHandler(this.Control_Canvas_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Control_Toolbox control_Toolbox1;
        private Control_Note control_Note1;
    }
}
