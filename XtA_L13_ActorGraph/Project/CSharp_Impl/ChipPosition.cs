using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Xenon.Aims.ActorGraph
{


    public abstract class ChipPosition
    {


        #region 用意
        //────────────────────────────────────────

        private const int HEIGHT_AREA = 60;

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 「│」
        /// </summary>
        /// <param name="areaY"></param>
        /// <returns></returns>
        public static Rectangle GetArrowMiddle(int areaY)
        {
            int y = areaY * ChipPosition.HEIGHT_AREA;
            return new Rectangle(0, y+20, 20, 20);
        }

        /// <summary>
        /// 「└」
        /// </summary>
        /// <param name="areaY"></param>
        /// <returns></returns>
        public static Rectangle GetArrowCurve(int areaY)
        {
            int y = areaY * ChipPosition.HEIGHT_AREA;
            return new Rectangle(0, y + 40, 20, 20);
        }

        /// <summary>
        /// 「├」
        /// </summary>
        /// <param name="areaY"></param>
        /// <returns></returns>
        public static Rectangle GetArrowBranch(int areaY)
        {
            int y = areaY * ChipPosition.HEIGHT_AREA;
            return new Rectangle(20, y+40, 20, 20);
        }

        /// <summary>
        /// 「─」１ワード目
        /// </summary>
        /// <param name="areaY"></param>
        /// <returns></returns>
        public static Rectangle GetArrowPointer1(int areaY)
        {
            int y = areaY * ChipPosition.HEIGHT_AREA;
            return new Rectangle(20, y + 0, 20, 20);
        }

        /// <summary>
        /// 「─」２ワード目
        /// </summary>
        /// <param name="areaY"></param>
        /// <returns></returns>
        public static Rectangle GetArrowPointer2(int areaY)
        {
            int y = areaY * ChipPosition.HEIGHT_AREA;
            return new Rectangle(40, y + 0, 20, 20);
        }

        /// <summary>
        /// 「→」
        /// </summary>
        /// <param name="areaY"></param>
        /// <returns></returns>
        public static Rectangle GetArrowPointer3(int areaY)
        {
            int y = areaY * ChipPosition.HEIGHT_AREA;
            return new Rectangle(40, y+20, 20, 20 + 8);
        }

        //────────────────────────────────────────

        /// <summary>
        /// 「│」
        /// </summary>
        /// <param name="areaY"></param>
        /// <returns></returns>
        public static Rectangle GetJointSingle(int areaY)
        {
            int y = areaY * ChipPosition.HEIGHT_AREA;
            return new Rectangle(0, y + 0, 20, 20);
            //return new Rectangle(60, y + 20, 20, 20);
            //return new Rectangle(80, y + 0, 20, 20);
        }

        //────────────────────────────────────────
        #endregion



    }
}
