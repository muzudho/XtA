namespace Xenon.Aims.ActorGraph
{
    partial class Form1
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.control_Perspective1 = new Xenon.Aims.ActorGraph.Control_Perspective();
            this.SuspendLayout();
            // 
            // control_Perspective1
            // 
            this.control_Perspective1.Location = new System.Drawing.Point(12, 12);
            this.control_Perspective1.Name = "control_Perspective1";
            this.control_Perspective1.Size = new System.Drawing.Size(447, 413);
            this.control_Perspective1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 432);
            this.Controls.Add(this.control_Perspective1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "アクターグラフ 0.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Control_Perspective control_Perspective1;
    }
}

