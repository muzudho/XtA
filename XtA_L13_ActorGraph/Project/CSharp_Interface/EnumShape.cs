using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.Aims.ActorGraph
{


    public enum EnumShape
    {

        /// <summary>
        /// デコレーションはない。
        /// </summary>
        Space,

        /// <summary>
        /// アローの「│」の部分。
        /// </summary>
        ArrowMiddle,

        /// <summary>
        /// 「└」の部分。
        /// </summary>
        ArrowCurve,

        /// <summary>
        /// 「├」の部分。
        /// </summary>
        ArrowBranch,

        /// <summary>
        /// 「─Add」や「─Create」の前部分。
        /// </summary>
        ArrowPointer1,

        /// <summary>
        /// 「─Add」や「─Create」の後部分。
        /// </summary>
        ArrowPointer2,

        /// <summary>
        /// 「→」の部分。
        /// </summary>
        ArrowPointer3,

        /// <summary>
        /// シーン名とシーン名をつなぐ短い「│」の部分。
        /// </summary>
        Joint,

        /// <summary>
        /// シーン名、またはアクター名。
        /// </summary>
        Name,

    }


}
