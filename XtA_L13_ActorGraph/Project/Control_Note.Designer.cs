namespace Xenon.Aims.ActorGraph
{
    partial class Control_Note
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
            this.SuspendLayout();
            // 
            // Control_Note
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Control_Note";
            this.Size = new System.Drawing.Size(470, 442);
            this.Load += new System.EventHandler(this.Control_Note_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Control_Note_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Control_Note_DragEnter);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Control_Note_Paint);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
