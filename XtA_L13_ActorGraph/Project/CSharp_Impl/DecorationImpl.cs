using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.Aims.ActorGraph
{


    /// <summary>
    /// １マス分のグラフィック。
    /// </summary>
    public class DecorationImpl
    {


        #region 生成と破棄
        //────────────────────────────────────────

        public DecorationImpl(EnumNode node, EnumShape shape)
        {
            this.Node = node;
            this.Shape = shape;
            this.Name = "";
        }

        /// <summary>
        /// ノード名。またはコメント。
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        public DecorationImpl(EnumNode node, string name)
        {
            this.Node = node;
            this.Shape = EnumShape.Name;
            this.Name = name;
        }

        //────────────────────────────────────────
        #endregion




        #region プロパティー
        //────────────────────────────────────────

        private string name;

        /// <summary>
        /// シーン名、またはアクター名。
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        //────────────────────────────────────────

        private EnumNode node;

        public EnumNode Node
        {
            get
            {
                return this.node;
            }
            set
            {
                this.node = value;
            }
        }

        //────────────────────────────────────────

        private EnumShape shape;

        public EnumShape Shape
        {
            get
            {
                return this.shape;
            }
            set
            {
                this.shape = value;
            }
        }

        //────────────────────────────────────────
        #endregion




    }
}
