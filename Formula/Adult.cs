using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Formula
{
    public partial class Adult
    {
        private int base_value = 14;
        private int max_value = 5;
        private int circ_factor = 1;
        private int resp_factor = 1;
        private int digest_factor = 1;
        private int urin_factor = 1;
        private int blood_factor = 1;
        private int endo_factor = 1;
        private int nutri_factor = 1;
        private int nerve_factor = 1;
        private int immu_factor = 1;
        private int move_factor = 1;
        private int sense_factor = 1;
        private int emotion_factor = 1;
        private int toxin_factor = 1;
        private int index_factor = 1;
        private int inher_factor = 1;
        private int meridian_factor = 1;
        private int herb_factor = 1;
        private int allergy_factor = 1;
        public string serialCode;
        public string sex;
        public string machineCode;
        public string companyID;
        private DJK.DAL.djk_SourceData  dal;
        private DJK.Model.djk_SourceData model;
        private List<InfoParser> infoList;
        private List<MatrixParser> matrixList;

        public Adult(int id)
        {

            init(id);

        }
        private void init(int id)
        {
            dal = new DJK.DAL.djk_SourceData();
            model = dal.GetModel(id);
            string infoTxt = model.infoData;
            string matrixTxt = model.matrixData;
            sex = model.sex.ToLower();
            serialCode = model.serialCode;
            machineCode = model.machineCode;
            companyID = model.companyID;
            infoList = JsonConvert.DeserializeObject<List<InfoParser>>(infoTxt);
            matrixList = JsonConvert.DeserializeObject<List<MatrixParser>>(matrixTxt);
            string ds = "";
        }

        /// <summary>
        /// 脑部 - 脑缺血可能
        /// </summary>
        /// <returns></returns> 
       [MyDescription("脑缺血可能","1_1_1")]
        public double naobu_nqx()
        {
            double rtn = 0;
            double e3 = value_E(circ_factor, 1875);
            double e4 = value_E(circ_factor, 5981);
            rtn = Math.Max(e3, e4);
            return rtn;
        }

        /// <summary>
        /// 脑部-脑中风可能
        /// </summary>
        /// <returns></returns>
       [MyDescription("脑中风可能","1_1_2")]
        public double naobu_nzf()
        {
            double rtn = 0;
            double e5 = value_E(circ_factor, 5525);
            double e6 = value_E(circ_factor, 5587);
            rtn = Math.Max(e5, e6);
            return rtn;
        }

        /// <summary>
        /// 脑部-脑血管受损可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("脑血管受损可能","1_1_3")]
        public double naobu_nxg()
        {
            double rtn = 0;
            double e7 = value_E(circ_factor, 5586);
            rtn = e7;
            return rtn;
        }

        /// <summary>
        /// 心脏-功能异常
        /// </summary>
        /// <returns></returns>
        [MyDescription("心脏功能异常","1_2_1")]
        public double xinzang_gnyc()
        {
            
            double e9 = value_E(circ_factor, 1808);
            double e10 = value_E(circ_factor, 6074);
            double e11 = value_E(circ_factor, 1858);
            double e12 = value_E(circ_factor, 5576);
            double e13 = value_E(circ_factor, 1858);
            double e14 = value_E(circ_factor, 5577);
            double e15 = value_E(circ_factor, 5567);
            double e16 = value_E(circ_factor, 2763);
            double e17 = value_E(circ_factor, 5826);
            double e18 = value_E(circ_factor, 1814);
            double e19 = value_E(circ_factor, 5506);
            double e20 = value_E(circ_factor, 5523);
            double f11 = Math.Max(e11, e13);
            f11 = Math.Max(f11, e12);
            double f14 = e14;
            double f15 = e15;
            double f16 = Math.Max(e16, e17);
            double f18 = e18;
            double f19 = e19;
            double f20 = e20;
            double rtn =Math.Max(e9,e10);
            rtn = Math.Max(rtn, f11);
            rtn = Math.Max(rtn, f14);
            rtn = Math.Max(rtn, f15);
            rtn = Math.Max(rtn, f16);
            rtn = Math.Max(rtn, f18);
            rtn = Math.Max(rtn, f19);
            rtn = Math.Max(rtn, f20);
            return rtn;
        }

        /// <summary>
        /// 心脏-心律不齐可能
        /// </summary>
        /// <returns></returns>
       [MyDescription("心律不齐可能","1_2_2")]
        public double xinzang_xlbq()
        {
            double e11 = value_E(circ_factor, 1858);
            double e12 = value_E(circ_factor, 5576);
            double e13 = value_E(circ_factor, 1858);
            double f11 = Math.Max(e11, e12);
            f11 = Math.Max(f11, e13);
            return f11;
        }

        /// <summary>
        /// 心脏-束支传导阻滞风险
        /// </summary>
        /// <returns></returns>
        [MyDescription("束支传导阻滞风险","1_2_3")]
        public double xinzang_szcdzz()
        {
            double e15= value_E(circ_factor, 5567);
            return e15;
        }

        /// <summary>
        /// 心脏-心肌供血不足可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("心肌供血不足可能","1_2_4")]
        public double xinzang_xjgxbz()
        {
            double e16 = value_E(circ_factor, 2763);
            double e17 = value_E(circ_factor, 5826);
            double f16 = Math.Max(e16, e17);
            return f16;
        }

        /// <summary>
        /// 心脏-心肌病风险
        /// </summary>
        /// <returns></returns>
        [MyDescription("心肌病风险","1_2_5")]
        public double xinzang_xjb()
        {
            double e18 = value_E(circ_factor, 1814);
            return e18;
        }

        /// <summary>
        /// 心脏-心绞痛风险
        /// </summary>
        /// <returns></returns>
        [MyDescription("心绞痛风险","1_2_6")]
        public double xinzang_xjt()
        {
            double e19 = value_E(circ_factor, 5506);
            return e19;
        }

        /// <summary>
        /// 心脏-主动脉硬化可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("主动脉硬化可能","1_2_7")]
        public double xinzang_zdmyh()
        {
            double e20 = value_E(circ_factor, 5523);
            return e20;
        }

        /// <summary>
        /// 微循环-毛细血管扩张可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("毛细血管扩张可能","1_3_1")]
        public double wxh_mxxgkz()
        {
            double e22 = value_E(circ_factor, 5966);
            return e22;
        }

        /// <summary>
        /// 血压-血压异常
        /// </summary>
        /// <returns></returns>
       [MyDescription("血压异常","1_4_1")]
        public double xy_xyyc() 
        {
            double e24 = value_E(circ_factor, 5737);
            double e25 = value_E(circ_factor, 1131);
            double e26 = value_E(circ_factor, 6098);
            double rtn = Math.Max(e24, e25);
            rtn = Math.Max(rtn, e26);
            List<int> dRange = new List<int> {112,277,483,658,712,963,1131,1242,1354,1356,1925,2474,2477,2478,2479,2480,2481,2482,2483,2484,2485,2486,2498,2517,2525,2653,2720,2822,2945,3127,3336,5737,5897,5913,6212,6214,6224,6229,6234,6373,6386,6392,6413,6420,6717,6801,8561,8846,8850 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count;i++ )
            {
                double d = value_D(circ_factor, dRange[i]);
                vRange.Add(d);
            }
            double c1493 = getMax(vRange);
            double d1493 = c1493 > max_value ? max_value : (c1493 < 0 ? 0 : c1493);
            rtn = Math.Max(rtn, d1493);
            return rtn;
        }

        /// <summary>
        /// 外周血管-动脉硬化可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("动脉硬化可能","1_5_1")]
        public double wzxg_dmyh()
        {
            double e28 = value_E(circ_factor, 3315);
            double e29 = value_E(circ_factor, 5528);
            double e30 = value_E(circ_factor, 1758);
            double f28 = Math.Max(e28, e29);
            f28 = Math.Max(f28, e30);
            return f28;
        }

        /// <summary>
        /// 外周血管-血液循环不良
        /// </summary>
        /// <returns></returns>
        [MyDescription("血液循环不良","1_5_2")]
        public double wzxg_xyxh()
        {
            double e31 = value_E(circ_factor, 6096);
            double e32 = info_LookUp(circ_factor, 295, 40);
            return Math.Max(e31,e32);
        }

        /// <summary>
        /// 症状感觉-头痛可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("头痛可能","1_6_1")]
        public double zzgj_tt()
        {
            double e34 = value_E(circ_factor, 2819);
            double e35 = value_E(circ_factor, 5814);
            double e36 = value_E(circ_factor, 5709);
            double f34 = Math.Max(e34, e35);
            f34 = Math.Max(f34, e36);
            return f34;
        }

        /// <summary>
        /// 症状感觉-心悸可能
        /// </summary>
        /// <returns></returns>
       [MyDescription("心悸可能","1_6_2")]
        public double zzgj_xj()
        {
            double e14 = value_E(circ_factor, 5577);
            return e14;
        }

        /// <summary>
        /// 呼吸系统-鼻窦炎可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("鼻窦炎可能","2_1_1")]
        public double hxxt_bdy()
        {
            double e39 = value_E(resp_factor, 5939);
            double e40 = value_E(resp_factor, 1824);
            double e41 = value_E(resp_factor, 2082);
            double f39 = Math.Max(e39, e40);
            f39 = Math.Max(f39, e41);
            return f39;
        }

        /// <summary>
        /// 呼吸系统-鼻炎可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("鼻炎可能","2_1_2")]
        public double hxxt_by()
        {
            double e43 = value_E(resp_factor, 5910);
            return e43;
        }

        /// <summary>
        /// 呼吸系统-嗅觉异常
        /// </summary>
        /// <returns></returns>
        [MyDescription("嗅觉异常","2_1_3")]
        public double hxxt_xj()
        {
            double e44 = value_E(resp_factor, 3613);
            return e44;
        }

        /// <summary>
        /// 咽喉-咽喉疾病风险
        /// </summary>
        /// <returns></returns>
        [MyDescription("咽喉疾病风险","2_2_1")]
        public double yh_yhjb()
        {
            double e46 = value_E(resp_factor, 3305);
            double e47 = value_E(resp_factor, 5779);
            double e48 = value_E(resp_factor, 5876);
            double e49 = value_E(resp_factor, 5941);
            double e50 = value_E(resp_factor, 5663);
            double f47 = e47;
            double f48 = Math.Max(e48, e49);
            double f50 = e50;
            double rtn = Math.Max(f47, f48);
            rtn = Math.Max(e47, rtn);
            rtn = Math.Max(rtn, f50);
            return rtn;
        }
        /// <summary>
        /// 咽喉-喉炎可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("喉炎可能","2_2_2")]
        public double yh_yy()
        {
            double e47 = value_E(resp_factor, 5779);
            return e47;
        }

        /// <summary>
        /// 咽喉-咽喉炎可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("咽喉炎可能","2_2_3")]
        public double yh_yhy()
        {
            double e48 = value_E(resp_factor, 5876);
            double e49 = value_E(resp_factor, 5941);
            double f48 = Math.Max(e48, e49);
            return f48;
        }

        /// <summary>
        /// 咽喉-会厌炎可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("会厌炎可能","2_2_4")]
        public double yh_hyy()
        {
            double e50 = value_E(resp_factor, 5663);
            return e50;
        }


        /// <summary>
        /// 气管-气管疾病风险
        /// </summary>
        /// <returns></returns>
       [MyDescription("气管疾病风险","2_3_1")]
        public double qg_qgjb()
        {
            double e52 = value_E(resp_factor, 3338);
            double e53 = value_E(resp_factor, 1835);
            double e54 = value_E(resp_factor, 1755);
            double e55 = value_E(resp_factor, 1561);
            double e56 = value_E(resp_factor, 5562);
            double e57 = value_E(resp_factor, 5563);
            List<int> dRange = new List<int>{36,75,219,595,1784,3216,3221,3245,3338,4032,4334,4990,5561,5562,5603,6267,6278,6433,6851,6937,7240,7463,7496,7830,7834,7847,8232,8864,9114,9116,9227,9329,9584,10055};
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D(resp_factor, dRange[i]);
                vRange.Add(d);
            }
            double f1692 = getMax(vRange);
            double g1692 = f1692 > max_value ? max_value : (f1692 < 0 ? 0 : f1692);
            List<double > mRange = new List<double> { e52,e53,e54,e55,e56,e57,g1692 };
            double rtn = getMax(mRange);
            return rtn;
        }

        /// <summary>
        /// 气管-支气管哮喘风险
        /// </summary>
        /// <returns></returns>
        [MyDescription("支气管哮喘风险","2_3_2")]
        public double qg_zqgxc()
        {
            double e54 = value_E(resp_factor, 1755);
            return e54;
        }

        /// <summary>
        /// 气管-急性支气管炎可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("急性支气管炎可能","2_3_3")]
        public double qg_jxzqgy()
        {
            double e55 = value_E(resp_factor, 1561);
            return e55;
        }

        /// <summary>
        /// 气管-慢性支气管炎可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("慢性支气管炎可能","2_3_4")]
        public double qg_mxzqgy()
        {
            double e56 = value_E(resp_factor, 5562);
            return e56;
        }

        /// <summary>
        /// 气管-喘息性支气管炎可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("喘息性支气管炎可能","2_3_5")]
        public double gq_cxxzqgy()
        {
            double e57 = value_E(resp_factor, 5563);
            return e57;
        }

        /// <summary>
        /// 肺-肺部功能异常
        /// </summary>
        /// <returns></returns>
        [MyDescription("肺部功能异常","2_4_1")]
        public double f_fbgnyc()
        {
            double e59 = value_E(resp_factor, 6075);
            double e60 = value_E(resp_factor, 1812);
            double e61 = value_E(resp_factor, 3342);
            double e62 = value_E(resp_factor, 6075);
            double e63 = value_E(resp_factor, 3337);
            double e64 = value_E(resp_factor, 5532);
            double e65 = value_E(resp_factor, 2035);
            double e66 = value_E(resp_factor, 5879);
            double e67 = value_E(resp_factor, 5880);
            double e68 = value_E(resp_factor, 5986);
            double e69 = value_E(resp_factor, 5794);
            double e70 = value_E(resp_factor, 5794);
            double e71 = value_E(resp_factor, 1868);
            double f63 = Math.Max(e63, e64);
            double f65 = Math.Max(e65, e66);
            double f67 = e67;
            double f69 = Math.Max(e69, e70);
            f69 = Math.Max(f69, e71);
            List<int> dRange = new List<int> { 9, 20, 39, 58, 62, 67, 141, 209, 210, 212, 214, 218, 220, 250, 264, 266, 327, 349, 353, 367, 369, 607, 633, 641, 680, 720, 738, 875, 900, 904, 942, 952, 984, 1025, 1050, 1051, 1064, 1085, 1280, 1304, 1375, 1388, 1469, 1488, 1752, 1765, 1815, 1871, 1883, 1976, 1984, 1999, 2010, 2038, 2042, 2045, 2058, 2059, 2068, 2075, 2099, 2108, 2337, 2338, 2369, 2374, 2575, 2629, 2637, 2697, 2698, 2701, 2738, 2745, 2962, 3002, 3130, 3140, 3154, 3201, 3239, 3344, 3345, 3479, 3802, 3880, 3903, 3904, 4027, 4990, 5000, 5069, 5077, 5079, 5170, 5219, 5302, 5495, 5496, 5521, 5601, 5654, 5655, 5704, 5797, 5878, 5881, 5882, 5883, 5897, 5898, 5899, 5900, 5916, 5919, 5940, 6033, 6078, 6161, 6731, 6745, 6769, 6778, 6782, 6887, 7205, 7206, 7246, 7417, 7461, 7468, 7473, 7474, 7536, 7603, 7655, 7656, 7679, 7724, 7727, 7774, 7842, 7843, 7845, 7846, 7847, 7849, 8030, 8850, 8871 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D(resp_factor, dRange[i]-3);
                vRange.Add(d);
            }
            double f1728 = getMax(vRange);
            double g1728 = f1728 > max_value ? max_value : (f1728 < 0 ? 0 : f1728);
            List<double> mRange = new List<double> { e59,e60,e61,e62,f63,f65,f67,f69,g1728 };
            double rtn = getMax(mRange);
            return rtn;
        }


        /// <summary>
        /// 肺-氧合指数
        /// </summary>
        /// <returns></returns>
       [MyDescription("氧合指数","2_4_2")]
        public double f_yhzs()
        {
            double c2688 = Double.Parse(infoList[17].Value) ;
            double d2688 = MathEx.RoundUp(Math.Abs(100 - c2688) / 12, 1);
            double e2688 = d2688 > max_value ? max_value : (d2688 < 0 ? 0 : d2688);
            return e2688;
        }


        /// <summary>
        /// 肺-哮喘可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("哮喘可能","2_4_3")]
        public double f_xc()
        {
            double e63 = value_E(resp_factor, 3337);
            double e64 = value_E(resp_factor, 5532);
            double f63 = Math.Max(e63, e64);
            return f63;
        }

        /// <summary>
        /// 肺-胸膜炎可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("胸膜炎可能","2_4_4")]
        public double f_xmy()
        {
            double e65 = value_E(resp_factor, 2035);
            double e66 = value_E(resp_factor, 5879);
            double f65 = Math.Max(e65, e66);
            return f65;
        }

        /// <summary>
        /// 肺-肺炎可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("肺炎可能","2_4_5")]
        public double f_fy()
        {
            double e67 = value_E(resp_factor, 5880);
            return e67;
        }

        /// <summary>
        /// 肺-肺结核可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("肺结核可能","2_4_6")]
        public double f_fjh()
        {
            double e68 = value_E(resp_factor, 5986);
            return e68;
        }

        /// <summary>
        /// 肺-肺部肿瘤风险
        /// </summary>
        /// <returns></returns>
        [MyDescription("肺部肿瘤风险","2_4_7")]
        public double f_fbzl()
        {
            double e69 = value_E(resp_factor, 5794);
            double e70 = value_E(resp_factor, 5794);
            double e71 = value_E(resp_factor, 1868);
            double f69 = Math.Max(e69, e70);
            f69 = Math.Max(f69, e71);
            return f69;
        }

        /// <summary>
        /// 症状感觉-鼻衄可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("鼻衄可能","2_5_1")]
        public double zzgj_bn()
        {
            double e73 = value_E(resp_factor, 5664);
            return e73;
        }
        /// <summary>
        /// 症状感觉-咳嗽可能 
        /// </summary>
        /// <returns></returns>
       [MyDescription("咳嗽可能","2_5_2")]
        public double zzgj_ks()
        {
            double e74 = value_E(resp_factor, 3341);
            double e75 = value_E(resp_factor, 5798);
            return Math.Max(e74, e75);
        }

        /// <summary>
        /// 症状感觉-感冒可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("感冒可能","2_5_3")]
        public double zzgj_gm()
        {
            double e76 = value_E(resp_factor, 5590);
            double e77 = value_E(resp_factor, 5762);
            return Math.Max(e76, e77);
        }
        /// <summary>
        /// 口腔-口腔功能异常
        /// </summary>
        /// <returns></returns>

        [MyDescription("口腔功能异常", "3_1_1")]
        public double kq_kqgnyc()
        {
            double f80 = 0;
            double e80 = value_E(digest_factor, 4154);
            double e81 = info_LookUp(digest_factor, 165, 75);
            double e82 = value_E(digest_factor, 6067);
            double e83 = value_E(digest_factor, 1799);
            double e84= value_E(digest_factor, 1920);
            double e85 = value_E(digest_factor, 2033);
            double e86 = value_E(digest_factor, 2036);
            double e87 = value_E(digest_factor, 5612);
            double e88 = value_E(digest_factor, 2135);
            List<double> dRange = new List<double> { e80,e81,e82,e83,e84,e85,e86,e87,e88};
            f80 = getMax(dRange);
            return f80;
        }
        /// <summary>
        /// 口腔-龋齿细菌过量
        /// </summary>
        /// <returns></returns>
       [MyDescription("龋齿细菌过量", "3_1_2")]
        public double kq_qcxjgl()
        {
            double e83 = value_E(digest_factor, 1799);
            return e83;
        }

        /// <summary>
       /// 口腔-齿龈炎可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("齿龈炎可能", "3_1_3")]
       public double kq_cyy()
       {
           double e84 = value_E(digest_factor, 1920);
           return e84;
       }


        /// <summary>
        /// 口腔-牙髓炎可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("牙髓炎可能", "3_1_4")]
        public double kq_yyy()
        {
            double e85 = value_E(digest_factor, 2033);
            return e85;
        }
        /// <summary>
        /// 口腔-牙周炎可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("牙周炎可能", "3_1_5")]
        public double kq_yzy()
        {
            double e86 = value_E(digest_factor, 2036);
            return e86;
        }

        /// <summary>
        /// 口腔-牙根病可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("牙根病可能", "3_1_6")]
        public double kq_ygb()
        {
            double e87 = value_E(digest_factor, 5612);
            return e87;
        }

        /// <summary>
        /// 口腔-下颌关节功能异常
        /// </summary>
        /// <returns></returns>
        [MyDescription("下颌关节功能异常", "3_1_7")]
        public double kq_xhgj()
        {
            double e88 = value_E(digest_factor, 2135);
            return e88;
        }

        /// <summary>
        /// 食管-食管炎可能
        /// </summary>
        /// <returns></returns>
        [MyDescription("食管炎可能", "3_2_1")]
        public double sg_sgy()
        {
            double e90 = value_E(digest_factor, 5726);
            return e90;
        }

        [MyDescription("胃部疾病风险", "3_3_1")]
        public double w_wbjb()
        {
            double e92 = value_E(digest_factor, 4155);
            double e93 = value_E(digest_factor, 5870);
            double e94 = value_E(digest_factor, 2141);
            double e95 = value_E(digest_factor, 3358);
            double e96 = value_E(digest_factor, 3887);
            List<double> mRange = new List<double> { e93,e94,e95,e96 };
            double f93 = getMax(mRange);
            double f97 = value_E(digest_factor, 5684);
            List<int> dRange = new List<int> { 8,413,420,508,621,696,784,961,1067,1213,1239,1269,1325,1446,1471,1713,1835,1893,2056,2100,2507,2510,2514,2515,2516,2517,2518,2519,2520,2521,2537,2714,2715,2724,2836,2837,4158,4168,5453,5644,5688,5689,5891,5955,6216,7799,8478,8479,8480,8996 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D(digest_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double c1439 = getMax(vRange);
            double d1439 = c1439 > max_value ? max_value : (c1439 < 0 ? 0 : c1439);
            List<double> fRange = new List<double> { e92, f93, f97, d1439 };
            double f92 = getMax(fRange);
            double rtn = getNoMore(4, f92);
            return rtn;
        }
        [MyDescription("胃溃疡风险", "3_3_2")]
        public double w_wky()
        {
            double e93 = value_E(digest_factor, 5870);
            double e94 = value_E(digest_factor, 2141);
            double e95 = value_E(digest_factor, 3358);
            double e96 = value_E(digest_factor, 3887);
            List<double> mRange = new List<double> { e93, e94, e95, e96 };
            double f93 = getMax(mRange);
            return f93;
        }
        [MyDescription("胃性贫血可能", "3_3_3")]
        public double w_wxpx()
        {
            double f97 = value_E(digest_factor, 5684);
            return f97;
        }
        [MyDescription("小肠功能异常", "3_4_1")]
        public double xc_xcgn()
        {
            double e99 = value_E(digest_factor, 4156);
            double e100 = value_E(digest_factor, 6068);
            double e101 = info_LookUp(digest_factor, 167, 75);
            double e102 = value_E(digest_factor, 5991);
            double f101 = Math.Max(e101, e102);
            double e103 = info_LookUp(digest_factor, 168, 75);
            double e104 = info_LookUp(digest_factor, 169, 75);
            List<double> mRange = new List<double> {e99,e100,e101,e103,e104 };
            double rtn = getMax(mRange);
            return rtn;
        }
        [MyDescription("十二指肠功能异常", "3_4_2")]
        public double xc_sezcgn()
        {
            double e101 = info_LookUp(digest_factor, 167, 75);
            double e102 = value_E(digest_factor, 5991);
            double f101 = Math.Max(e101, e102);
            return f101;
        }
        [MyDescription("空肠异常", "3_4_3")]
        public double xc_kcgn()
        {
            double e103 = info_LookUp(digest_factor, 168, 75);
            return e103;
        }
        [MyDescription("回肠功能异常", "3_4_4")]
        public double xc_hcgn()
        {
            double e104 = info_LookUp(digest_factor, 169, 75);
            return e104;
        }

        [MyDescription("结肠功能异常", "3_5_1")]
        public double jc_jcgn()
        {
            double e106 = value_E(digest_factor, 4158);
            double e107 = value_E(digest_factor, 6069);
            double e108 = info_LookUp(digest_factor, 170, 75);
            double e109 = value_E(digest_factor, 5633);
            double e110 = value_E(digest_factor, 2140);
            double e111 = value_E(digest_factor, 5992);
            double f110 = Math.Max(e110, e111);
            double e112 = value_E(digest_factor, 5658);
            f110 = Math.Max(f110, e112);
            double e113 = value_E(digest_factor, 5588);
            List<double> mRange = new List<double> {e106,e107,e108,e109,f110,e113 };
            double rtn = getMax(mRange);
            return rtn;
        }
        [MyDescription("憩室炎可能", "3_5_2")]
        public double jc_xsy()
        {
            double e109 = value_E(digest_factor, 5633);
            return e109;
        }
        [MyDescription("结肠炎可能", "3_5_3")]
        public double jc_jcy()
        {
            double e110 = value_E(digest_factor, 2140);
            double e111 = value_E(digest_factor, 5992);
            double f110 = Math.Max(e110, e111);
            double e112 = value_E(digest_factor, 5658);
            f110 = Math.Max(f110, e112);
            return f110;
        }
        [MyDescription("结肠肿瘤风险", "3_5_4")]
        public double jc_jczl()
        {
            double e113 = value_E(digest_factor, 5588);
            return e113;
        }
        [MyDescription("痔疮可能", "3_6_1")]
        public double zcgg_zc()
        {
            double e115 = value_E(digest_factor, 3381);
            double e116 = value_E(digest_factor, 5714);
            double f115 = Math.Max(e115, e116);
            return f115;
        }
        [MyDescription("肛裂可能", "3_6_2")]
        public double zcgg_gl()
        {
            double e117 = value_E(digest_factor, 5501);
            return e117;
        }

        [MyDescription("肝脏功能异常", "3_7_1")]
        public double g_gzgn()
        {
            double e119 = value_E(digest_factor, 1818);
            double e120 = value_E(digest_factor, 4159);
            double e121 = value_E(digest_factor, 1941);
            double e122 = value_E(digest_factor, 5717);
            double e123 = value_E(digest_factor, 5718);
            double e124 = value_E(digest_factor, 6070);
            List<int> dRange = new List<int> { 1944, 1947, 1948, 1949, 1969, 2009, 5720, 5751, 5722, 5775, 5847, 6073, 6074, 7458, 7472, 7666, 7667, 7668, 7669, 9801, 9802, 9803, 9804, 9805, 9806, 9807, 9808, 9809 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D(digest_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double f1643 = getMax(vRange);
            double g1643 = f1643 > max_value ? max_value : (f1643 < 0 ? 0 : f1643);
            List<double> mRange = new List<double> { e121, e122, e123, e124, g1643 };
            double f121 = getMax(mRange);
            double e125 = value_E(digest_factor, 1860);
            double e126 = value_E(digest_factor, 6071);
            double e127 = value_E(digest_factor, 5883);
            double f125 = Math.Max(e125, Math.Max(e126, e127));
            double e128 = value_E(digest_factor, 5705);
            double e129 = value_E(digest_factor, 5719);
            double f128 = Math.Max(e128, e129);
            List<int> dRange2 = new List<int> { 17, 48, 89, 129, 191, 216, 348, 425, 480, 482, 496, 505, 518, 531, 583, 628, 646, 685, 719, 743, 792, 794, 903, 931, 971, 1028, 1053, 1054, 1057, 1063, 1153, 1187, 1220, 1256, 1260, 1267, 1304, 1347, 1349, 1354, 1377, 1380, 1386, 1425, 1447, 1755, 1786, 1791, 1821, 1863, 1896, 1908, 1911, 1920, 1924, 1944, 1947, 1948, 1949, 1969, 2009, 2010, 2051, 2152, 2153, 2155, 2338, 2369, 2513, 2676, 2693, 2964, 2985, 3006, 3012, 3013, 3042, 3095, 3160, 3161, 3163, 3177, 3184, 3198, 3222, 3223, 3234, 3650, 3714, 3862, 4045, 4075, 4117, 4162, 4306, 4310, 4314, 4329, 4977, 5022, 5028, 5098, 5179, 5191, 5310, 5359, 5482, 5545, 5548, 5556, 5708, 5719, 5720, 5721, 5722, 5775, 5847, 5886, 5887, 6013, 6017, 6034, 6073, 6074, 6144, 6161, 6265, 6361, 6409, 6479, 6498, 6536, 6698, 6730, 6828, 6829, 6830, 6878, 6883, 7030, 7031, 7086, 7094, 7205, 7206, 7218, 7234, 7236, 7281, 7311, 7458, 7461, 7472, 7478, 7479, 7480, 7485, 7489, 7490, 7495, 7496, 7497, 7506, 7507, 7523, 7525, 7530, 7541, 7546, 7568, 7589, 7660, 7666, 7667, 7668, 7669, 7675, 8505, 8506, 8507, 8508, 8541, 8561, 8579, 8583, 8618, 8628, 8667, 8725, 8780, 8784, 8793, 8827, 8828, 8829, 8837, 8874, 8879, 8958, 9028, 9029, 9032, 9049, 9051, 9060, 9086, 9136, 9147, 9192, 9220, 9254, 9263, 9271, 9272, 9273, 9801, 9802, 9803, 9804, 9805, 9806, 9807, 9808, 9809 };
            List<double> vRange2 = new List<double>();
            for (int i = 0; i < dRange2.Count; i++)
            {
                double d = value_D(digest_factor, dRange2[i] - 3);
                vRange2.Add(d);
            }
            double c1643 = getMax(vRange2);
            double d1643 = c1643 > max_value ? max_value : (c1643 < 0 ? 0 : c1643);
            List<double> mRange2 = new List<double> { e119, e120, f121, f128, d1643 };
            double f119 = getMax(mRange2);
            double rtn = getNoMore(4, f119);
            return rtn;

        }
        [MyDescription("肝脏炎症可能", "3_7_2")]
        public double g_gzyz()
        {
            double e121 = value_E(digest_factor, 1941);
            double e122 = value_E(digest_factor, 5717);
            double e123 = value_E(digest_factor, 5718);
            double e124 = value_E(digest_factor, 6070);
            List<int> dRange = new List<int> { 1944, 1947, 1948, 1949, 1969, 2009, 5720, 5751, 5722, 5775, 5847, 6073, 6074, 7458, 7472, 7666, 7667, 7668, 7669, 9801, 9802, 9803, 9804, 9805, 9806, 9807, 9808, 9809 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D(digest_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double f1643 = getMax(vRange);
            double g1643 = f1643 > max_value ? max_value : (f1643 < 0 ? 0 : f1643);
            List<double> mRange = new List<double> { e121, e122, e123, e124, g1643 };
            double f121 = getMax(mRange);
            return f121;
        }
        [MyDescription("肝硬化风险", "3_7_3")]
        public double g_gyh()
        {
            double e125 = value_E(digest_factor, 1860);
            double e126 = value_E(digest_factor, 6071);
            double e127 = value_E(digest_factor, 5883);
            double f125 = Math.Max(e125, Math.Max(e126, e127));
            return f125;
        }
        [MyDescription("肝肿瘤风险", "3_7_4")]
        public double g_gzl()
        {
            double e128 = value_E(digest_factor, 5705);
            double e129 = value_E(digest_factor, 5719);
            double f128 = Math.Max(e128, e129);
            return f128;
        }
        [MyDescription("胆道功能异常", "3_8_1")]
        public double d_ddgn()
        {
            double e131 = value_E(digest_factor, 5553);
            double e132 = value_E(digest_factor, 6072);
            double e133 = value_E(digest_factor, 5682);
            double e134 = value_E(digest_factor, 5683);
            double e135 = value_E(digest_factor, 5682);
            double f131 = Math.Max(Math.Max(e131, e132), Math.Max(e133, e134));
            return f131;

        }
        [MyDescription("胆结石可能", "3_8_2")]
        public double d_djs()
        {
            double e135 = value_E(digest_factor, 5682);
            double e136 = value_E(digest_factor, 5683);
            double f135 = Math.Max(e135, e136);
            List<int> dRange = new List<int> {125,422,668,1277,1510,3249,5685,5686,7507,7610,7874,7875,9736 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D(digest_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double f1518 = getMax(vRange);
            double g1518 = f1518 > max_value ? max_value : (f1518 < 0 ? 0 : f1518);
            f135 = Math.Max(f135, g1518);
            return f135;
        }
        [MyDescription("胰腺功能异常", "3_9_1")]
        public double y_yxgn()
        {
            double e138 = value_E(digest_factor, 3356);
            double e139 = value_E(digest_factor, 4161);
            double e140 = value_E(digest_factor, 6073);
            double e141 = value_E(digest_factor, 5861);
            double f138 = Math.Max(Math.Max(e138, e139), Math.Max(e140, e141));
            return f138;
        }
        [MyDescription("胰腺炎可能", "3_9_2")]
        public double y_yxx()
        {
            double e141 = value_E(digest_factor, 5861);
            return e141;
        }
        [MyDescription("消化不良", "3_11_1")]
        public double xh_xhbl()
        {
            double e143 = value_E(digest_factor, 5760);
            double e144 = value_E(digest_factor, 5641);
            double e145 = info_LookUp(digest_factor, 110, 75);
            double e146 = value_E(digest_factor, 2829);
            double e147 = value_E(digest_factor, 2017);
            double e148 = value_E(digest_factor, 5799);
            double e149 = info_LookUp(digest_factor, 171, 75);
            List<double> mRange = new List<double> { e143, e144, e145, e146, e147, e148, e149 };
            double rtn = getMax(mRange);
            return rtn;
        }
        [MyDescription("蛋白质消化不良", "3_11_2")]
        public double xh_dbzxhbl()
        {
            double e145 = info_LookUp(digest_factor, 110, 75);
            return e145;
        }
        [MyDescription("吸收不良", "3_11_3")]
        public double xh_xsbl()
        {
            double e146 = value_E(digest_factor, 2829);
            double e147 = value_E(digest_factor, 2017);
            double e148 = value_E(digest_factor, 5799);
            double rtn = Math.Max(e146, Math.Max(e147, e148));
            return rtn;
        }
        [MyDescription("肠道菌群紊乱", "3_11_4")]
        public double xh_cdjqwl()
        {
            double e149 = info_LookUp(digest_factor, 171, 75);
            return e149;
        }
        [MyDescription("牙痛可能", "3_12_1")]
        public double zzgj_yt()
        {
            double e151 = value_E(digest_factor, 5979);
            return e151;
        }
        [MyDescription("胃肠胀气可能", "3_12_2")]
        public double zzgj_wczq()
        {
            double e152 = value_E(digest_factor, 5674);
            double e153 = value_E(digest_factor, 3354);
            double f152 = Math.Max(e152, e153);
            return f152;
        }
        [MyDescription("胃痛可能", "3_12_3")]
        public double zzgj_wt()
        {
            double e154 = value_E(digest_factor, 5952);
            return e154;
        }
        [MyDescription("呃逆可能", "3_12_4")]
        public double zzgj_ey()
        {
            double e155 = value_E(digest_factor, 5727);
            return e155;
        }
        [MyDescription("烧心可能", "3_12_5")]
        public double zzgj_sx()
        {
            double e156 = value_E(digest_factor, 3353);
            return e156;
        }
        [MyDescription("腹泻可能", "3_12_6")]
        public double zzgj_fx()
        {
            double e157 = value_E(digest_factor, 5626);
            return e157;
        }
        [MyDescription("便秘可能", "3_12_7")]
        public double zzgj_bm()
        {
            double e158 = value_E(digest_factor, 5594);
            return e158;
        }
        [MyDescription("脂肪泻可能", "3_12_8")]
        public double zzgj_zfx()
        {
            double e159 = value_E(digest_factor, 2825);
            return e159;
        }
        [MyDescription("肾脏功能异常", "4_1_1")]
        public double sz_szgn()
        {
            double e163 = info_LookUp(urin_factor, 317, 40);
            double e164 = value_E(urin_factor, 1811);
            double e165 = value_E(urin_factor, 1976);
            double e166 = value_E(urin_factor, 5835);
            double e167 = value_E(urin_factor, 1925);
            double e168 = value_E(urin_factor, 5691);
            double e169 = value_E(urin_factor, 5834);
            double e170 = value_E(urin_factor, 1975);
            double e171 = value_E(urin_factor, 5904);
            double e172 = value_E(urin_factor, 5905);
            double e173 = value_E(urin_factor, 1977);
            double e174 = value_E(urin_factor, 2767);
            double e175 = value_E(urin_factor, 5898);
            double e176 = value_E(urin_factor, 5899);
            double e177 = value_E(urin_factor, 5999);
            double e178 = value_E(urin_factor, 5774);
            List<double> mRange = new List<double> { e163, e164, e165, e166, e167, e168, e169, e170, e171, e172, e173, e174, e175, e176, e177, e178 };
            double f163 = getMax(mRange);
            return f163;
        }
        [MyDescription("肾小球性肾炎风险", "4_1_2")]
        public double sz_sxqxsy()
        {
            double e167 = value_E(urin_factor, 1925);
            double e168 = value_E(urin_factor, 5691);
            double f167 = Math.Max(e167, e168);
            return f167;
        }
        [MyDescription("慢性肾炎风险", "4_1_3")]
        public double sz_mxsy()
        {
            double e169 = value_E(urin_factor, 5834);
            return e169;
        }
        [MyDescription("肾囊肿可能", "4_1_4")]
        public double sz_snz()
        {
            double e170 = value_E(urin_factor, 1975);
            return e170;
        }
        [MyDescription("肾结石可能", "4_1_5")]
        public double sz_sjs()
        {
            double e171 = value_E(urin_factor, 5904);
            double e172 = value_E(urin_factor, 5905);
            double e173 = value_E(urin_factor, 1977);
            double e174 = value_E(urin_factor, 2767);
            List<int> dRange = new List<int> { 28, 52, 152, 175, 177, 185, 353, 433, 514, 539, 852, 963, 1206, 1266, 1312, 1607, 1620, 1980, 2071, 2145, 2709, 2767, 2768, 2769, 2770, 3157, 3204, 3648, 5908, 6478, 7084, 8870, 9138 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D(urin_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double f1544 = getMax(vRange);
            double g1544 = f1544 > max_value ? max_value : (f1544 < 0 ? 0 : f1544);
            List<double> mRange = new List<double> { e171, e172, e173, e174, g1544 };
            double f171 = getMax(mRange);
            return f171;
        }
        [MyDescription("肾盂肾炎可能", "4_1_6")]
        public double sz_sysy()
        {
            double e175 = value_E(urin_factor, 5898);
            double e176 = value_E(urin_factor, 5899);
            double f175 = Math.Max(e175, e176);
            return f175;
        }
        [MyDescription("肾功能失调可能", "4_1_7")]
        public double sz_sgnst()
        {
            double e177 = value_E(urin_factor, 5999);
            return e177;
        }
        [MyDescription("膀胱息肉可能", "4_3_1")]
        public double pg_pgxr()
        {
            double e182= value_E(urin_factor, 1793);
            double e183 = value_E(urin_factor, 1822);
            double f182 = Math.Max(e182, e183);
            return f182;
        }
        [MyDescription("膀胱炎可能", "4_3_2")]
        public double pg_pgy()
        {
            double e184 = value_E(urin_factor, 1798);
            double e185 = value_E(urin_factor, 1822);
            double f184 = Math.Max(e184, e185);
            return f184;
        }
        [MyDescription("尿道炎可能", "4_4_1")]
        public double? ld_ldy()
        {
            double e192 = value_E(urin_factor, 2139);
            double e193 = value_E(urin_factor, 5996);
            double e194 = value_E(urin_factor, 2137);
            double f192 = Math.Max(e192, Math.Max(e193, e194));
            if (sex == "female")
            {
                return null;
            }
            else
            {
                return f192;
            }
        }
        [MyDescription("尿路感染可能", "4_4_2")]
        public double? ld_llgr()
        {
            double e195 = value_E(urin_factor, 5998);
            double e196 = value_E(urin_factor, 2137);
            double f195 = Math.Max(e195, e196);
            if(sex == "male")
            {
                return null;
            }
            else
            {
                return f195;
            }
        }
        [MyDescription("尿路结石可能", "4_4_3")]
        public double ld_lljs()
        {
            double e197 = value_E(urin_factor, 2142);
            double e198 = value_E(urin_factor, 5995);
            double e171 = value_E(urin_factor, 5904);
            double e172 = value_E(urin_factor, 5905);
            double e173 = value_E(urin_factor, 1977);
            double e174 = value_E(urin_factor, 2767);
            List<int> dRange = new List<int> { 28, 52, 152, 175, 177, 185, 353, 433, 514, 539, 852, 963, 1206, 1266, 1312, 1607, 1620, 1980, 2071, 2145, 2709, 2767, 2768, 2769, 2770, 3157, 3204, 3648, 5908, 6478, 7084, 8870, 9138 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D(urin_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double f1544 = getMax(vRange);
            double g1544 = f1544 > max_value ? max_value : (f1544 < 0 ? 0 : f1544);
            List<double> mRange = new List<double> { e171, e172, e173, e174, g1544 };
            double f171 = getMax(mRange);
            double f197 = Math.Max(f171, Math.Max(e197, e198));
            return f197;
        }
        [MyDescription("尿失禁风险", "4_5_1")]
        public double zzgj_lsj()
        {
            double e201= value_E(urin_factor, 6002);
            return e201;
        }
        [MyDescription("蛋白尿可能", "4_5_2")]
        public double zzgj_dbl()
        {
            double e202 = value_E(urin_factor, 6109);
            return e202;
        }
        [MyDescription("血尿风险", "4_5_3")]
        public double zzgj_xl()
        {
            double e203 = value_E(urin_factor, 5712);
            return e203;
        }

        [MyDescription("乳腺异常", "5_1_1")]
        public double? sz_rxyc()
        {
            double e206 = value_E(urin_factor, 1815);
            double e207 = value_E(urin_factor, 6080);
            double e208 = value_E(urin_factor, 2002);
            double e209 = value_E(urin_factor, 5804);
            double e210 = value_E(urin_factor, 2003);
            double e211 = value_E(urin_factor, 5673);
            double e212 = value_E(urin_factor, 5560);
            List<double> mRange = new List<double> { e206, e207, e208, e209, e210, e211, e212 };
            double f206 = getMax(mRange);
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return f206;
            }
        }
        [MyDescription("乳腺异常", "5_1_2")]
        public double? sz_rxy()
        {
            double e208 = value_E(urin_factor, 2002);
            double e209 = value_E(urin_factor, 5804);
            double f208 = Math.Max(e208, e209);
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return f208;
            }
        }
        [MyDescription("乳腺纤维瘤", "5_1_3")]
        public double? sz_rxxwl()
        {
            double e210 = value_E(urin_factor, 2003);
            double e211 = value_E(urin_factor, 5673);
            double f210 = Math.Max(e210, e211);
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return f210;
            }
        }
        [MyDescription("乳腺肿瘤", "5_1_4")]
        public double? sz_rxzl()
        {
            double e212 = value_E(urin_factor, 5560);
            double e213 = value_E(urin_factor, 1856);
            double f212 = Math.Max(e212, e213);
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return f212;
            }
        }
        [MyDescription("乳腺肿瘤", "5_2_1")]
        public double? sz_zgyc()
        {
            double e215 = value_E(urin_factor, 6078);
            double e216 = value_E(urin_factor, 1833);
            double e217 = value_E(urin_factor, 5889);
            double e218 = value_E(urin_factor, 1891);
            double f215 = Math.Max(Math.Max(e215, e216), Math.Max(e217, e218));
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return f215;
            }
        }
        [MyDescription("乳腺肿瘤", "5_2_2")]
        public double? sz_zgxc()
        {
            double e217 = value_E(urin_factor, 5889);
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return e217;
            }
        }
        [MyDescription("乳腺肿瘤", "5_2_3")]
        public double? sz_zgnmyw()
        {
            double e218 = value_E(urin_factor, 1891);
            double e219 = value_E(urin_factor, 5657);
            double f218 = Math.Max(e218, e219);
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return f218;
            }
        }

        [MyDescription("宫颈异常", "5_3_1")]
        public double? sz_gjyc()
        {
            double e221 = value_E(urin_factor, 6077);
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return e221;
            }
        }
        [MyDescription("卵巢囊肿可能", "5_4_1")]
        public double? fj_lcnz()
        {
            double e223 = value_E(urin_factor, 2027);
            double e224 = value_E(urin_factor, 5854);
            double e225 = value_E(urin_factor, 1823);
            double f223 = Math.Max(e223, Math.Max(e223, e224));
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return f223;
            }
        }
        [MyDescription("多囊卵巢可能", "5_4_2")]
        public double? fj_dnlc()
        {
            double e226 = value_E(urin_factor, 5948);
            double e227 = value_E(urin_factor, 1823);
            double f226 = Math.Max(e226, e227);
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return f226;
            }
        }
        [MyDescription("卵巢炎可能", "5_4_3")]
        public double? fj_lcy()
        {
            double e228 = value_E(urin_factor, 2027);
            double e229 = value_E(urin_factor, 5854);
            double e230 = value_E(urin_factor, 1823);
            double f228 = Math.Max(e228, Math.Max(e229, e230));
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return f228;
            }
        }
        [MyDescription("附件炎可能", "5_4_4")]
        public double? fj_fjy()
        {
            double e231 = value_E(urin_factor, 1747);
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return e231;
            }
        }
        [MyDescription("阴道炎可能", "5_6_1")]
        public double? yd_ydy()
        {
            double e233 = value_E(urin_factor, 2146);
            double e234 = value_E(urin_factor, 6004);
            double e235 = value_E(urin_factor, 2104);
            double f233 = Math.Max(e233, Math.Max(e234, e235));
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return f233;
            }
        }
        [MyDescription("前列腺炎可能", "5_8_1")]
        public double? qlx_qlxy()
        {
            double e187 = value_E(urin_factor, 5890);
            double e188 = value_E(urin_factor, 5549);
            double e189 = value_E(urin_factor, 1829);
            double f187 = Math.Max(e187, Math.Max(e188, e189));
            if (sex == "female")
            {
                return null;
            }
            else
            {
                return f187;
            }
        }
        [MyDescription("前列腺肿瘤风险", "5_8_2")]
        public double? qlx_qlxzl()
        {
            double e190 = value_E(urin_factor, 2044);
            if (sex == "female")
            {
                return null;
            }
            else
            {
                return e190;
            }
        }

        [MyDescription("生殖器疱疹可能", "5_9_1")]
        public double wszq_bz()
        {
            double e238 = value_E(urin_factor, 5722);
            return e238;
        }

        [MyDescription("睾丸异常", "5_10_1")]
        public double? gw_gwyc()
        {
            double e240 = value_E(urin_factor, 6076);
            double e241 = value_E(urin_factor, 5662);
            double f240 = Math.Max(e240, e241);
            if (sex == "female")
            {
                return null;
            }
            else
            {
                return f240;
            }
        }
        [MyDescription("附睾炎可能", "5_10_2")]
        public double? gw_fgy()
        {
            double e241 = value_E(urin_factor, 5662);
            if (sex == "female")
            {
                return null;
            }
            else
            {
                return e241;
            }
        }

        [MyDescription("阳痿可能", "5_11_1")]
        public double? zzgj_yw()
        {
            double e243 = value_E(urin_factor, 5758);
            if (sex == "female")
            {
                return null;
            }
            else
            {
                return e243;
            }
        }
        [MyDescription("遗精可能", "5_11_2")]
        public double? zzgj_yj()
        {
            double e244 = value_E(urin_factor, 5942);
            if (sex == "female")
            {
                return null;
            }
            else
            {
                return e244;
            }

        }
        [MyDescription("崩漏可能", "5_11_3")]
        public double? zzgj_bl()
        {
            double e245 = value_E(urin_factor, 6001);
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return e245;
            }
        }

        [MyDescription("白血病风险", "6_1_1")]
        public double xyxt_bxb()
        {
            double e248 = value_E(blood_factor, 1983);
            double e249 = value_E(blood_factor, 1804);
            double e250 = value_E(blood_factor, 2737);
            double f248 = Math.Max(e248, Math.Max(e249, e250));
            return f248;
        }
        [MyDescription("多发性骨髓瘤风险", "6_1_2")]
        public double xyxt_gsl()
        {
            double e251 = value_E(blood_factor, 5818);
            return e251;
        }
        [MyDescription("粒细胞缺乏症可能", "6_2_1")]
        public double xy_lxbqfz()
        {
            double e253 = value_E(blood_factor, 5481);
            return e253;
        }
        [MyDescription("白细胞功能异常", "6_2_2")]
        public double xy_bxgyc()
        {
            double e254 = value_E(blood_factor, 1991);
            return e254;
        }
        [MyDescription("过敏性紫癜可能", "6_2_3")]
        public double xy_gmxzd()
        {
            double e255 = value_E(blood_factor, 5502);
            return e255;
        }
        [MyDescription("遗传性红细胞增多症可能", "6_2_4")]
        public double xy_hxbzd()
        {
            double e256 = value_E(blood_factor, 5720);
            return e256;
        }
        [MyDescription("镰状细胞性贫血可能", "6_2_5")]
        public double xy_lzxbpx()
        {
            double e257 = value_E(blood_factor, 5748);
            return e257;
        }
        [MyDescription("凝血酶原偏低可能", "6_2_6")]
        public double xy_nxmypd()
        {
            double e258 = value_E(blood_factor, 5750);
            return e258;
        }
        [MyDescription("急性白血病风险", "6_2_7")]
        public double xy_jxbxb()
        {
            double e259 = value_E(blood_factor, 5784);
            return e259;
        }
        [MyDescription("慢性白血病风险", "6_2_8")]
        public double xy_mxbxb()
        {
            double e260 = value_E(blood_factor, 5785);
            return e260;
        }
        [MyDescription("白血球减少症可能", "6_2_9")]
        public double xy_bxqjsz()
        {
            double e261 = value_E(blood_factor, 5786);
            return e261;
        }
        [MyDescription("单核细胞增多症可能", "6_2_10")]
        public double xy_dhxbzdz()
        {
            double e262 = value_E(blood_factor, 5816);
            double e263 = value_E(blood_factor, 5761);
            double e264 = value_E(blood_factor, 6010);
            double f262 = Math.Max(e262, Math.Max(e263, e264));
            return f262;
        }
        [MyDescription("血小板增多症可能", "6_2_11")]
        public double xy_xxbzdz()
        {
            double e265 = value_E(blood_factor, 5974);
            return e265;
        }
        [MyDescription("血红蛋白异常可能", "6_2_12")]
        public double xy_xhdbyc()
        {
            double e266 = value_E(blood_factor, 6084);
            return e266;
        }
        [MyDescription("贫血可能", "6_3_1")]
        public double zzgj_px()
        {
            double e268 = value_E(blood_factor, 5503);
            double e269 = value_E(blood_factor, 2821);
            double f268 = Math.Max(e268, e269);
            return f268;
        }

        [MyDescription("甲状腺机能亢进可能", "7_2_1")]
        public double jzx_jnkj()
        {
            double e272 = value_E(endo_factor, 1953);
            double e273 = value_E(endo_factor, 5975);
            double e274 = value_E(endo_factor, 5738);
            double f272 = Math.Max(e272, Math.Max(e273, e274));
            double e275 = value_E(endo_factor, 5752);
            double e276 = value_E(endo_factor, 5751);
            double e277 = value_E(endo_factor, 2823);
            double e278 = value_E(endo_factor, 1956);
            double f275 = Math.Max(Math.Max(e275, e276), Math.Max(e277, e278));
            double rtn = f272 > f275 ? f272 : 0.1;
            return rtn;
        }
        [MyDescription("甲状腺机能减退可能", "7_2_2")]
        public double jzx_jnsj()
        {
            double e272 = value_E(endo_factor, 1953);
            double e273 = value_E(endo_factor, 5975);
            double e274 = value_E(endo_factor, 5738);
            double f272 = Math.Max(e272, Math.Max(e273, e274));
            double e275 = value_E(endo_factor, 5752);
            double e276 = value_E(endo_factor, 5751);
            double e277 = value_E(endo_factor, 2823);
            double e278 = value_E(endo_factor, 1956);
            double f275 = Math.Max(Math.Max(e275, e276), Math.Max(e277, e278));
            double rtn = f275 > f272 ? f275 : 0.1;
            return rtn;
        }

        [MyDescription("弥漫性毒性甲状腺肿可能", "7_2_3")]
        public double jzx_dxjzxz()
        {
            double e279 = value_E(endo_factor, 6041);
            return e279;
        }

        [MyDescription("慢性甲状腺炎可能", "7_2_4")]
        public double jzx_mxjzxy()
        {
            double e280 = value_E(endo_factor, 6050);
            return e280;
        }
        [MyDescription("甲状腺肿瘤风险", "7_2_5")]
        public double jzx_mxzl()
        {
            double e281 = value_E(endo_factor, 5693);
            double e282 = value_E(endo_factor, 1828);
            double e283 = value_E(endo_factor, 2546);
            double f281 = Math.Max(e281, Math.Max(e282, e283));
            return f281;
        }

        [MyDescription("甲状旁腺异常可能", "7_2_6")]
        public double jzx_jzpxjc()
        {
            double e285 = value_E(endo_factor, 5736);
            double e286 = value_E(endo_factor, 5747);
            double e287 = value_E(endo_factor, 6083);
            double e288 = value_E(endo_factor, 1826);
            double e289 = value_E(endo_factor, 1440);
            double e290 = value_E(endo_factor, 2555);
            List<double> mRange = new List<double> { e285, e286, e287, e288, e289, e290 };
            double rtn = getMax(mRange);
            return rtn;
        }

        [MyDescription("下丘脑功能异常", "7_3_1")]
        public double xqn_xqnyc()
        {
            double e292 = value_E(endo_factor, 1837);
            return e292;
        }

        [MyDescription("下丘脑功能异常", "7_3_2")]
        public double xqn_jsyc()
        {
            double e293 = value_E(endo_factor, 2471);
            return e293;
        }

        [MyDescription("促黄体生成素释放激素异常", "7_3_3")]
        public double xqn_chtscs()
        {
            double e294 = value_E(endo_factor, 2472);
            return e294;
        }

        [MyDescription("松果体激素异常", "7_4_1")]
        public double sgt_jsyc()
        {
            double e296 = value_E(endo_factor, 2470);
            return e296;
        }

        [MyDescription("促甲状腺激素释放激素异常", "7_5_1")]
        public double ct_cjzxjssf()
        {
            double e298 = value_E(endo_factor, 2561);
            return e298;
        }

        [MyDescription("加压素异常", "7_5_2")]
        public double ct_jysyc()
        {
            double e299 = value_E(endo_factor, 2525);
            return e299;
        }

        [MyDescription("垂体功能异常", "7_5_3")]
        public double ct_cjgnyc()
        {
            double e300 = value_E(endo_factor, 1830);
            double e301 = value_E(endo_factor, 1802);
            double e302 = value_E(endo_factor, 6082);
            double f300 = Math.Max(e300, Math.Max(e301, e302));
            return f300;
        }

        [MyDescription("垂体瘤风险", "7_5_4")]
        public double ct_ctl()
        {
            double e303 = value_E(endo_factor, 2057);
            return e303;
        }

        [MyDescription("尿崩症可能", "7_5_5")]
        public double ct_lbz()
        {
            double e304 = value_E(endo_factor, 5620);
            return e304;
        }

        [MyDescription("皮质醇异常", "7_6_1")]
        public double ssx_pzcyc()
        {
            double e307 = value_E(endo_factor, 2531);
            return e307;
        }
        [MyDescription("肾上腺功能异常", "7_6_2")]
        public double ssx_gbyc()
        {
            double e308 = value_E(endo_factor, 1800);
            double e309 = value_E(endo_factor, 1834);
            double e310 = info_LookUp(endo_factor, 330, 40);
            double e311 = value_E(endo_factor, 2822);
            double e312 = value_E(endo_factor, 5471);
            double e313 = value_E(endo_factor, 1768);
            double e314 = value_E(endo_factor, 5468);
            double e315 = value_E(endo_factor, 5473);
            double e316 = value_E(endo_factor, 5485);
            double e317 = value_E(endo_factor, 5604);
            List<double> mRange = new List<double> { e308, e309, e310, e311, e312, e313, e314, e315, e316, e317 };
            double f308 = getMax(mRange);
            return f308;
        }
        [MyDescription("肾上腺机能减退可能", "7_6_3")]
        public double ssx_jnjt()
        {
            double e310 = info_LookUp(endo_factor, 330, 40);
            double e311 = value_E(endo_factor, 2822);
            double e312 = value_E(endo_factor, 5471);
            double e313 = value_E(endo_factor, 1768);
            List<double> mRange = new List<double> { e310, e311, e312, e313 };
            double f310 = getMax(mRange);
            return f310;
        }
        [MyDescription("阿狄森氏病风险", "7_6_4")]
        public double ssx_adssb()
        {
            double e314 = value_E(endo_factor, 5468);
            return e314;
        }
        [MyDescription("肾上腺肿瘤风险", "7_6_5")]
        public double ssx_zl()
        {
            double e315 = value_E(endo_factor, 5473);
            return e315;
        }
        [MyDescription("醛固酮增多症风险", "7_6_6")]
        public double ssx_qgtzdz()
        {
            double e316 = value_E(endo_factor, 5485);
            return e316;
        }
        [MyDescription("柯兴氏综合征风险", "7_6_7")]
        public double ssx_kxszhz()
        {
            double e317 = value_E(endo_factor, 5604);
            return e317;
        }

        [MyDescription("胰岛素异常", "7_7_1")]
        public double yd_ydsyc()
        {
            double e319 = value_E(endo_factor, 2539);
            return e319;
        }
        [MyDescription("胰蛋白酶异常", "7_7_2")]
        public double yd_ydbmyc()
        {
            double e316 = value_E(endo_factor, 2728);
            return e316;
        }
        [MyDescription("糖尿病风险", "7_7_3")]
        public double yd_tlb()
        {
            double e321 = value_E(endo_factor, 2827);
            double e391 = value_E(nutri_factor, 5808);
            double e392 = value_E(nutri_factor, 5623);
            double f391 = Math.Max(e391, e392);
            double e448 = info_LookUp(nutri_factor, 302, 40);
            double e449 = value_E(nutri_factor, 5618);
            double e450 = value_E(nutri_factor, 5619);
            double e451 = value_E(nutri_factor, 5621);
            double e452 = value_E(nutri_factor, 5616);
            double e453 = value_E(nutri_factor, 5622);
            double e454 = value_E(nutri_factor, 5765);
            List<double> mRange = new List<double> { e448, e449, e450, e451, e452, e453, e454 };
            double f448 = getMax(mRange);
            List<int> dRange = new List<int> { 123, 133, 248, 330, 572, 644, 963, 2179, 2205, 2557, 1886, 3155, 2830, 2845, 5392, 5618, 5619, 5620, 5621, 5622, 5623, 5624, 5625, 5626, 5627, 6353, 6354, 6570, 6710, 6711, 7039, 7038, 8576 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D(endo_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double f1439 = getMax(vRange);
            double g1439 = f1439 > max_value ? max_value : (f1439 < 0 ? 0 : f1439);
            double e345 = info_LookUp(nutri_factor, 302, 75);
            double e346 = value_E(nutri_factor, 3329);
            double e347 = value_E(nutri_factor, 3930);
            double e348 = info_LookUp(nutri_factor, 128, 75);
            double e349 = value_E(nutri_factor, 566);
            double e350 = info_LookUp(nutri_factor, 129, 75);
            double e351 = info_LookUp(nutri_factor, 130, 75);
            double e352 = info_LookUp(nutri_factor, 131, 75);
            List<double> mRange2 = new List<double> { e345, e345, e347, e348, e349, e350, e351,e352 };
            double f345 = getMax(mRange2);
            List<double> mRange3 = new List<double> { e321, f391, f448, g1439, f345 };
            double f321 = getMax(mRange3) - 0.5;
            return f321;

        }
        [MyDescription("荷尔蒙失调", "7_8_1")]
        public double xjs_hemst()
        {
            double e323 = info_LookUp(endo_factor, 322, 40);
            double e324 = value_E(endo_factor, 2549);
            double e325 = value_E(endo_factor, 2805);
            double e326 = value_E(endo_factor, 2556);
            double e327 = value_E(endo_factor, 2801);
            double e328 = value_E(endo_factor, 2560);
            double e329 = value_E(endo_factor, 1451);
            double e330 = value_E(endo_factor, 2804);
            double e331 = value_E(endo_factor, 2473);
            List<double> mRange = new List<double> { e323, e324, e325, e326, e327, e328, e329, e330, e331 };
            double f323 = getMax(mRange);
            return f323;
        }
        [MyDescription("雌激素异常", "7_8_2")]
        public double xjs_cjsyc()
        {
            double e324 = value_E(endo_factor, 2549);
            double e325 = value_E(endo_factor, 2805);
            double f324 = Math.Max(e324, e325);
            double rtn = 0;
            if (sex == "male")
            {
                rtn = f324 > 0.5 ? 0.5 : f324;
            }
            else
            {
                rtn = f324;
            }
            return f324;

        }

        [MyDescription("黄体酮异常", "7_8_3")]
        public double xjs_httyc()
        {
            double e326 = value_E(endo_factor, 2556);
            double e327 = value_E(endo_factor, 2801);
            double f326 = Math.Max(e326, e327);
            double rtn = 0;
            if (sex == "male")
            {
                rtn = f326 > 0.6 ? 0.6 : f326;
            }
            else
            {
                rtn = f326;
            }
            return f326;
        }

        [MyDescription("睾酮异常", "7_8_4")]
        public double xjs_gtyc()
        {
            double e328 = value_E(endo_factor, 2560);
            double e329 = value_E(endo_factor, 1451);
            double e330 = value_E(endo_factor, 2804);
            double f328 = Math.Max(e328, Math.Max(e329, e328));
            double rtn = 0;
            if (sex == "female")
            {
                rtn = f328 > 0.5 ? 0.5 : f328;
            }
            else
            {
                rtn = f328;
            }
            return f328;
        }

        [MyDescription("促黄体生成素异常", "7_8_5")]
        public double xjs_chtszs()
        {
            double e331 = value_E(endo_factor, 2473);
            double rtn = 0;
            if (sex == "male")
            {
                rtn = e331 > 0.4 ? 0.4 : e331;
            }
            else
            {
                rtn = e331;
            }
            return rtn;

        }
        [MyDescription("内分泌失调", "7_9_1")]
        public double gjzz_nfmst()
        {
            List<int> dRange = new List<int> { 1956, 5978, 5741, 5755, 5754, 2826, 1959, 6044, 6053, 5696, 1831, 2549, 5739, 5750, 6086, 1829, 1443, 2558, 1840, 2474, 2475, 2473, 2564, 2528, 1833, 1805, 6085, 2060, 5623, 5641, 2534, 1803, 1837, 2825, 5474, 1771, 5471, 5476, 5488, 5607, 2542, 2731, 2830, 2552, 2808, 2559, 2804, 2563, 1454, 2807, 2476 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_E(endo_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e310 = info_LookUp(endo_factor, 330, 40);
            double e323 = info_LookUp(endo_factor, 322, 40);
            vRange.Add(e310);
            vRange.Add(e323);
            double f333 = getMax(vRange);
            double e335 = value_E(endo_factor, 5812);
            double e336 = value_E(endo_factor, 2818);
            double e337 = value_E(endo_factor, 1884);
            double e338 = value_E(endo_factor, 5640);
            double e339 = value_E(endo_factor, 5810);
            double e340 = value_E(endo_factor, 5811);
            double e341 = value_E(endo_factor, 5495);
            double e342 = value_E(endo_factor, 5886);
            List<double> mRange = new List<double> { e335, e336, e337, e338, e339, e340, e341, e342 };
            double f335 = getMax(mRange);
            double rtn = Math.Max(f333, f335);
            return rtn;
        }
        [MyDescription("月经不调", "7_9_2")]
        public double? gjzz_yjbt()
        {
            double e335 = value_E(endo_factor, 5812);
            double e336 = value_E(endo_factor, 2818);
            double e337 = value_E(endo_factor, 1884);
            double e338 = value_E(endo_factor, 5640);
            List<double> mRange = new List<double> { e335, e336, e337, e338 };
            double f335 = getMax(mRange);
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return f335;
            }
        }
        [MyDescription("更年期综合症", "7_9_3")]
        public double? gjzz_gnqzhz()
        {
            double e339 = value_E(endo_factor, 5810);
            double e340 = value_E(endo_factor, 5811);
            double f339 = Math.Max(e339, e340);
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return f339;
            }
        }

        [MyDescription("闭经", "7_9_4")]
        public double? gjzz_bj()
        {
            double e341 = value_E(endo_factor, 5495);
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return e341;
            }
        }
        [MyDescription("经前期紧张综合征", "7_9_5")]
        public double? gjzz_jqqjzzhz()
        {
            double e342 = value_E(endo_factor, 5886);
            if (sex == "male")
            {
                return null;
            }
            else
            {
                return e342;
            }
        }

        [MyDescription("多巴胺", "7_9_6")]
        public double gjzz_dba()
        {
            double d2693 = value_E2(endo_factor, 597);
            double d2694 = value_E2(endo_factor, 721);
            double d2695 = value_E2(endo_factor, 2474);
            double d2696 = value_E2(endo_factor, 5324);
            double d2697 = value_E2(endo_factor, 5430);
            List<double> mRange = new List<double> { d2693, d2694, d2695, d2696, d2697 };
            double d2692 = getMax(mRange);
            return d2692;
        }

        [MyDescription("催产素", "7_9_7")]
        public double gjzz_ccs()
        {
            double k323 = value_E(1, 2523);
            return k323;
        }
        [MyDescription("5-羟色胺", "7_9_8")]
        public double gjzz_jsa()
        {
            double d2700 = value_E2(endo_factor, 940);
            double d2701 = value_E2(endo_factor, 2475);
            double d2702 = value_E2(endo_factor, 2740);
            double d2703 = value_E2(endo_factor, 5286);
            double d2704 = value_E2(endo_factor, 5321);
            double d2705 = value_E2(endo_factor, 6384);
            double d2706 = value_E2(endo_factor, 6623);
            double d2707 = value_E2(endo_factor, 6624);
            List<double> mRange = new List<double> { d2700, d2701, d2702, d2703, d2704, d2705, d2706, d2707 };
            double d2699 = getMax(mRange);
            return d2699;
        }
        [MyDescription("果糖代谢异常", "8_1_1")]
        public double gt_gtdxyc()
        {
            double e345 = info_LookUp(nutri_factor, 127, 75);
            return e345;
        }
        [MyDescription("麦芽糖代谢异常", "8_1_2")]
        public double gt_mytdxyc()
        {
            double e348 = info_LookUp(nutri_factor, 128, 75);
            return e348;
        }

        [MyDescription("葡萄糖代谢异常", "8_1_3")]
        public double gt_pttdxyc()
        {
            double e349 = value_E(nutri_factor, 566);
            double e350 = info_LookUp(nutri_factor, 129, 75);
            double f349 = Math.Max(e349, e350);
            return f349;
        }

        [MyDescription("乳糖代谢异常", "8_1_4")]
        public double gt_rtdxyc()
        {
            double e351 = info_LookUp(nutri_factor, 130, 75);
            return e351;
        }

        [MyDescription("蔗糖代谢异常", "8_1_5")]
        public double gt_ztdxyc()
        {
            double e352 = info_LookUp(nutri_factor, 131, 75);
            return e352;
        }
        [MyDescription("甘油三酯代谢异常", "8_2_1")]
        public double xz_gysz()
        {
            double e354 = info_LookUp(nutri_factor, 131, 75);
            List<int> dRange = new List<int> { 1440,1552,2193,3962,6247 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double f1511 = getMax(vRange);
            double g1511= f1511 > max_value ? max_value : (f1511 < 0 ? 0 : f1511);
            double rtn = Math.Max(e354, g1511);
            return rtn;
        }

        [MyDescription("胆固醇代谢异常", "8_2_2")]
        public double xz_dgc()
        {
            double e355 = info_LookUp(nutri_factor, 306, 40);
            double e356 = value_E(nutri_factor, 1201);
            double e357 = value_E(nutri_factor, 3923);
            List<int> dRange = new List<int> { 341, 1204, 1216, 1433, 1440, 1470, 2666, 2667, 2863, 3098, 3238, 3926, 6037, 6235, 6247, 6406 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double f1493 = getMax(vRange);
            double g1493 = f1493 > max_value ? max_value : (f1493 < 0 ? 0 : f1493);
            double f355 = Math.Max(Math.Max(e355, e356), Math.Max(e357, g1493));
            Random rd = new Random();
            double dResult;
            dResult = rd.NextDouble();
            double rtn = Math.Round(f355 - 1 + dResult, 1);
            return rtn;
        }

        [MyDescription("必需脂肪酸不足", "8_2_3")]
        public double xz_zfs()
        {
            double e358 = value_E(nutri_factor, 429);
            return e358;
        }

        [MyDescription("丙胺酸缺乏", "8_3_1")]
        public double dbz_binas()
        {
            double e360 = value_E2(nutri_factor, 372);
            return e360;
        }
        [MyDescription("天门冬氨酸缺乏", "8_3_2")]
        public double dbz_tianmdas()
        {
            double e361 = value_E2(nutri_factor, 373);
            return e361;
        }
        [MyDescription("精氨酸缺乏", "8_3_3")]
        public double dbz_jingas()
        {
            double e362 = value_E2(nutri_factor, 378);
            return e362;
        }
        [MyDescription("半胱氨酸缺乏", "8_3_4")]
        public double dbz_bangas()
        {
            double e363 = value_E2(nutri_factor, 393);
            return e363;
        }
        [MyDescription("甘氨酸缺乏", "8_3_5")]
        public double dbz_ganas()
        {
            double e364 = value_E2(nutri_factor, 406);
            return e364;
        }
        [MyDescription("亮氨酸缺乏", "8_3_6")]
        public double dbz_liangas()
        {
            double e365 = value_E2(nutri_factor, 415);
            return e365;
        }
        [MyDescription("蛋氨酸缺乏", "8_3_7")]
        public double dbz_danas()
        {
            double e366 = value_E2(nutri_factor, 422);
            return e366;
        }

        [MyDescription("赖氨酸缺乏", "8_3_8")]
        public double dbz_laias()
        {
            double e367 = value_E2(nutri_factor, 426);
            return e367;
        }

        [MyDescription("苯丙氨酸缺乏", "8_3_9")]
        public double dbz_bingas()
        {
            double e368 = value_E2(nutri_factor, 433);
            double e369 = value_E2(nutri_factor, 1196);
            double f368 = Math.Max(e368, e369);
            return f368;
        }
        [MyDescription("丝氨酸缺乏", "8_3_10")]
        public double dbz_sias()
        {
            double e370 = value_E2(nutri_factor, 452);
            return e370;
        }
        [MyDescription("色氨酸缺乏", "8_3_11")]
        public double dbz_seas()
        {
            double e371 = value_E2(nutri_factor, 453);
            return e371;
        }
        [MyDescription("酪氨酸缺乏", "8_3_12")]
        public double dbz_geas()
        {
            double e372 = value_E2(nutri_factor, 455);
            return e372;
        }
        [MyDescription("苏氨酸缺乏", "8_3_13")]
        public double dbz_suas()
        {
            double e373 = value_E2(nutri_factor, 456);
            return e373;
        }
        [MyDescription("牛磺酸缺乏", "8_3_14")]
        public double dbz_niuas()
        {
            double e374 = value_E2(nutri_factor, 458);
            return e374;
        }
        [MyDescription("缬氨酸缺乏", "8_3_15")]
        public double dbz_jieas()
        {
            double e375 = value_E2(nutri_factor, 459);
            return e375;
        }
        [MyDescription("异亮氨酸缺乏", "8_3_16")]
        public double dbz_yilas()
        {
            double e376 = value_E2(nutri_factor, 555);
            return e376;
        }
        [MyDescription("组氨酸缺乏", "8_3_17")]
        public double dbz_zuas()
        {
            double e377 = value_E2(nutri_factor, 563);
            return e377;
        }
        [MyDescription("伽玛氨基丁酸缺乏", "8_3_18")]
        public double dbz_kamas()
        {
            double e378 = value_E2(nutri_factor, 2551);
            return e378;
        }

        [MyDescription("谷氨酰胺缺乏", "8_3_19")]
        public double dbz_gkxa()
        {
            double e379 = value_E2(nutri_factor, 5410);
            return e379;
        }
        [MyDescription("左旋肉碱缺乏", "8_3_20")]
        public double dbz_zxrj()
        {
            double e380 = value_E2(nutri_factor, 6188);
            return e380;
        }

        [MyDescription("尿酸代谢异常", "8_4_1")]
        public double ls_lsdx()
        {
            double e382 = value_E(nutri_factor, 3961);
            List<int> dRange = new List<int> { 236, 287, 463, 893, 1682, 2139, 3964, 6267, 6278, 7252 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double f1586 = getMax(vRange);
            double g1586 = f1586 > max_value ? max_value : (f1586 < 0 ? 0 : f1586);
            double rtn = Math.Max(e382, g1586);
            return rtn;
        }
        [MyDescription("胆汁分泌异常", "8_5_1")]
        public double g_dzfm()
        {
            double e384 = value_E(nutri_factor, 1806);
            return e384;
        }
        [MyDescription("胰腺酶缺乏", "8_6_1")]
        public double y_yxm()
        {
            double e386 = value_E(nutri_factor, 2707);
            return e386;
        }
        [MyDescription("淀粉酶缺乏", "8_6_2")]
        public double y_dfm()
        {
            double e387 = value_E(nutri_factor, 1221);
            double e388 = value_E(nutri_factor, 3912);
            double f387 = Math.Max(e387, e388);
            return f387;
        }
        [MyDescription("蛋白酶缺乏", "8_6_3")]
        public double y_dbm()
        {
            double e389 = value_E(nutri_factor, 2650);
            return e389;
        }
        [MyDescription("脂肪酶缺乏", "8_6_4")]
        public double y_zfm()
        {
            double k386 = value_E(1, 2697);
            return k386;
        }
        [MyDescription("糖尿病肾病风险", "8_7_1")]
        public double s_tlb()
        {
            double e391 = value_E(nutri_factor, 5808);
            double e392 = value_E(nutri_factor, 5623);
            double f391 = Math.Max(e391, e392);
            return f391;
        }
        [MyDescription("维生素 A 缺乏", "8_8_1")]
        public double wss_a()
        {
            List<int> dRange = new List<int> { 780, 781, 3858, 3965, 4134, 4167, 6014, 6134, 7314, 8903, 8904, 8921 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2352 = getMax(vRange);
            double f2352 = e2352 > max_value ? max_value : (e2352 < 0 ? 0 : e2352);
            return f2352;
        }
        [MyDescription("维生素 B1 缺乏", "8_8_2")]
        public double wss_b1()
        {
            List<int> dRange = new List<int> { 414, 765, 1105, 1265, 3855, 6015, 6158, 7317, 8198, 8199, 8669, 8905 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2364= getMax(vRange);
            double f2364 = e2364 > max_value ? max_value : (e2364 < 0 ? 0 : e2364);
            return f2364;
        }
        [MyDescription("维生素 B2 缺乏", "8_8_3")]
        public double wss_b2()
        {
            List<int> dRange = new List<int> { 766, 6016, 6025, 6157, 8201, 8670, 8906 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2376 = getMax(vRange);
            double f2376 = e2376 > max_value ? max_value : (e2376 < 0 ? 0 : e2376);
            return f2376;
        }
        [MyDescription("维生素 B12 缺乏", "8_8_4")]
        public double wss_b12()
        {
            List<int> dRange = new List<int> { 594, 5138, 6017, 6129, 6147, 6488, 6489, 7313, 8202, 8203, 8204, 8680, 8909 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2419 = getMax(vRange);
            double f2419 = e2419 > max_value ? max_value : (e2419 < 0 ? 0 : e2419);
            return f2419;
        }
        [MyDescription("维生素 C 缺乏", "8_8_5")]
        public double wss_c()
        {
            List<int> dRange = new List<int> { 74, 389, 730, 782, 923, 1219, 2101, 2658, 2992, 3090, 4118, 4127, 4129, 6018, 6167, 6490, 6491, 6492, 6737, 7049, 7323, 7324, 8189, 8206, 8913, 8914, 8915, 8919, 8925, 8941, 9700 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2432 = getMax(vRange);
            double f2432 = e2432 > max_value ? max_value : (e2432 < 0 ? 0 : e2432);
            return f2432;
        }
        [MyDescription("维生素 D 缺乏", "8_8_6")]
        public double wss_d()
        {
            List<int> dRange = new List<int> { 584, 1450, 1451, 1452, 3966, 6019, 7327, 8926 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2463 = getMax(vRange);
            double f2463 = e2463 > max_value ? max_value : (e2463 < 0 ? 0 : e2463);
            return f2463;
        }
        [MyDescription("维生素 E 缺乏", "8_8_7")]
        public double wss_e()
        {
            List<int> dRange = new List<int> { 783, 3004, 4001, 4121, 6020, 6211, 6400, 6494, 7050, 7328, 7367, 8916, 8917, 8927 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2471 = getMax(vRange);
            double f2471 = e2471 > max_value ? max_value : (e2471 < 0 ? 0 : e2471);
            return f2471;
        }
        [MyDescription("辅酶 Q10 缺乏", "8_8_8")]
        public double wss_q10()
        {
            List<int> dRange = new List<int> { 399, 593, 3872, 4119, 6186, 6405, 6476, 7348, 7349, 7424, 8920, 8962, 8968, 9019, 9036, 9244, 9619 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2643 = getMax(vRange);
            double f2643 = e2643 > max_value ? max_value : (e2643 < 0 ? 0 : e2643);
            return f2643;
        }
        [MyDescription("叶酸缺乏", "8_8_9")]
        public double wss_ys()
        {
            List<int> dRange = new List<int> { 384, 407, 636, 773, 3879, 4009, 4169, 5175, 6022, 6128, 6212, 6302, 6429, 7370 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2405 = getMax(vRange);
            double f2405 = e2405 > max_value ? max_value : (e2405 < 0 ? 0 : e2405);
            return f2405;
        }
        [MyDescription("维生素 B3 缺乏", "8_8_10")]
        public double wss_b3()
        {
            List<int> dRange = new List<int> { 777, 778, 3854, 6127, 8907 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2383 = getMax(vRange);
            double f2383 = e2383 > max_value ? max_value : (e2383 < 0 ? 0 : e2383);
            return f2383;
        }
        [MyDescription("维生素 B5 缺乏", "8_8_11")]
        public double wss_b5()
        {
            List<int> dRange = new List<int> { 775, 6159, 8671, 8908 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2388 = getMax(vRange);
            double f2388 = e2388 > max_value ? max_value : (e2388 < 0 ? 0 : e2388);
            return f2388;
        }
        [MyDescription("维生素 B6 缺乏", "8_8_12")]
        public double wss_b6()
        {
            List<int> dRange = new List<int> { 520, 521, 767, 3854, 5122, 5190, 6166, 6486, 6487, 7312, 7376, 8674, 8923 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2392 = getMax(vRange);
            double f2392 = e2392 > max_value ? max_value : (e2392 < 0 ? 0 : e2392);
            return f2392;
        }
        [MyDescription("水分指数", "8_10_1")]
        public double sdjz_sf()
        {
            double c2687 = Double.Parse(infoList[16].Value);
            double d2687 = MathEx.RoundUp(Math.Abs(100 - c2687) / 12, 1);
            double e2687 = d2687 > max_value ? max_value : (d2687 < 0 ? 0 : d2687);
            return e2687;
        }
        [MyDescription("矿物质铬缺乏", "8_10_2")]
        public double sdjz_luo()
        {
            List<int> dRange = new List<int> { 602, 2746, 2982, 2988, 6137, 6198, 6443, 7346, 7350, 8954, 9243 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2564 = getMax(vRange);
            double f2564 = e2564 > max_value ? max_value : (e2564 < 0 ? 0 : e2564);
            return f2564;
        }

        [MyDescription("矿物质钾缺乏", "8_10_3")]
        public double sdjz_jia()
        {
            List<int> dRange = new List<int> { 522, 776, 1176, 3951, 5371, 5748, 6150, 6203, 6377, 8943, 9275 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2513 = getMax(vRange);
            double f2513 = e2513 > max_value ? max_value : (e2513 < 0 ? 0 : e2513);
            return f2513;
        }
        [MyDescription("矿物质钙缺乏", "8_10_4")]
        public double sdjz_gai()
        {
            List<int> dRange = new List<int> { 420, 1282, 2986, 2987, 3229, 3406, 3995, 4136, 5045, 5127, 5128, 5129, 5130, 5370, 6124, 6180, 6187, 6197, 6233, 6303, 6438, 7047, 7237, 7340, 7341, 8929, 8930, 9125 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2485 = getMax(vRange);
            double f2485 = e2485 > max_value ? max_value : (e2485 < 0 ? 0 : e2485);
            return f2485;
        }
        [MyDescription("矿物质镁缺乏", "8_10_5")]
        public double sdjz_mei()
        {
            List<int> dRange = new List<int> { 495, 497, 498, 499, 539, 547, 1266, 2749, 3940, 5374, 6202, 6501, 6790, 7047, 7192, 7403, 7598, 8222, 8933, 8934, 8935 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2524 = getMax(vRange);
            double f2524 = e2524 > max_value ? max_value : (e2524 < 0 ? 0 : e2524);
            return f2524;
        }
        [MyDescription("矿物质硫缺乏", "8_10_6")]
        public double sdjz_liu()
        {
            List<int> dRange = new List<int> {1147,1247,5375 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2632 = getMax(vRange);
            double f2632 = e2632 > max_value ? max_value : (e2632 < 0 ? 0 : e2632);
            return f2632;
        }
        [MyDescription("矿物质锰缺乏", "8_10_7")]
        public double sdjz_meng()
        {
            List<int> dRange = new List<int> { 493, 538, 2748, 5168, 5376, 5377, 7193, 7404, 7405, 8951 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2554 = getMax(vRange);
            double f2554 = e2554 > max_value ? max_value : (e2554 < 0 ? 0 : e2554);
            return f2554;
        }
        [MyDescription("矿物质锌缺乏", "8_10_8")]
        public double sdjz_xin()
        {
            List<int> dRange = new List<int> { 770, 1274, 1477, 1478, 3045, 3117, 5246, 5378, 6181, 6204, 6401, 7074, 7200, 7430, 7431, 8946, 8947, 8948, 8955 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2575 = getMax(vRange);
            double f2575 = e2575 > max_value ? max_value : (e2575 < 0 ? 0 : e2575);
            return f2575;
        }

        [MyDescription("矿物质硒缺乏", "8_10_9")]
        public double sdjz_xi()
        {
            List<int> dRange = new List<int> { 779, 1131, 1252, 4128, 5379, 6162, 7421, 7422, 8944, 8945, 8953 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2594 = getMax(vRange);
            double f2594 = e2594 > max_value ? max_value : (e2594 < 0 ? 0 : e2594);
            return f2594;
        }

        [MyDescription("矿物质磷缺乏", "8_10_10")]
        public double sdjz_lin()
        {
            List<int> dRange = new List<int> { 5381,7199};
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2615 = getMax(vRange);
            double f2615 = e2615 > max_value ? max_value : (e2615 < 0 ? 0 : e2615);
            return f2615;
        }

        [MyDescription("矿物质硼缺乏", "8_10_11")]
        public double sdjz_peng()
        {
            List<int> dRange = new List<int> { 2754, 5382, 6125, 601 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2617 = getMax(vRange);
            double f2617 = e2617 > max_value ? max_value : (e2617 < 0 ? 0 : e2617);
            return f2617;
        }
        [MyDescription("矿物质钼缺乏", "8_10_12")]
        public double sdjz_mu()
        {
            List<int> dRange = new List<int> { 2754, 5382, 6125, 601 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2636 = getMax(vRange);
            double f2636 = e2636 > max_value ? max_value : (e2636 < 0 ? 0 : e2636);
            return f2636;
        }
        [MyDescription("矿物质硅缺乏", "8_10_13")]
        public double sdjz_gui()
        {
            double e412 = value_E(nutri_factor, 5381);
            return e412;
        }
        [MyDescription("矿物质钴缺乏", "8_10_14")]
        public double sdjz_gu()
        {
            List<int> dRange = new List<int> { 2744,5385,7122,7191 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2636 = getMax(vRange);
            double f2636 = e2636 > max_value ? max_value : (e2636 < 0 ? 0 : e2636);
            return f2636;
        }
        [MyDescription("矿物质锂缺乏", "8_10_15")]
        public double sdjz_li()
        {
            double e414 = value_E(nutri_factor, 5383);
            return e414;
        }
        [MyDescription("矿物质锗缺乏", "8_10_16")]
        public double sdjz_zhe()
        {
            List<int> dRange = new List<int> { 4313,5387,6408,6454 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2625 = getMax(vRange);
            double f2625 = e2625 > max_value ? max_value : (e2625 < 0 ? 0 : e2625);
            return f2625;
        }
        [MyDescription("矿物质锡缺乏", "8_10_17")]
        public double sdjz_xii()
        {
            double e5390 = value_E2(nutri_factor, 5387);
            return e5390;
        }

        [MyDescription("矿物质钒缺乏", "8_10_18")]
        public double sdjz_fan()
        {
            List<int> dRange = new List<int> { 5392,6139,7429 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2629 = getMax(vRange);
            double f2629 = e2629 > max_value ? max_value : (e2629 < 0 ? 0 : e2629);
            return f2629;
        }
        [MyDescription("矿物质铜缺乏", "8_10_19")]
        public double sdjz_tong()
        {
            double e422 = value_E(nutri_factor, 5391);
            return e422;
        }
        [MyDescription("矿物质铁缺乏", "8_10_20")]
        public double sdjz_tie()
        {
            List<int> dRange = new List<int> { 769,1344,1348,3939,4133,6024,6209,6251,9253 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D2(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e2545 = getMax(vRange);
            double f2545 = e2545 > max_value ? max_value : (e2545 < 0 ? 0 : e2545);
            return f2545;
        }
        [MyDescription("营养不良", "8_11_1")]
        public double yyzt_yybl()
        {
            double e428 = value_E(nutri_factor, 2828);
            double e429 = value_E(nutri_factor, 5802);
            double e430 = value_E(nutri_factor, 6035);
            double f428 = Math.Max(e428, Math.Max(e429, e430));
            return f428;
        }
        [MyDescription("酸碱度指数", "8_12_1")]
        public double sjd_zs()
        {
            double c = Double.Parse(infoList[18].Value);
            double d = MathEx.RoundUp(Math.Abs(75 - c) / 2.5, 1);
            double e = d > max_value ? max_value : (d < 0 ? 0 : d);
            return e;
        }
        [MyDescription("褐色脂肪异常", "8_13_1")]
        public double fpzs_hszf()
        {
            double e445 = value_E(nutri_factor, 1803);
            return e445;
        }
        [MyDescription("体脂肪指数异常", "8_13_2")]
        public double fpzs_tzf()
        {
            double e446 = value_E(nutri_factor, 5858);
            List<int> dRange = new List<int> { 146, 196, 215, 221, 351, 383, 431, 508, 623, 702, 729, 795, 815, 854, 1130, 1442, 1560, 1645, 1806, 2826, 2930, 2960, 3040, 3156, 3175, 3227, 3806, 3817, 4351, 4628, 5252, 5307, 5569, 5754, 5755, 5861, 6417, 6417, 6481, 6573, 6639, 6640, 6780, 6780, 6885, 7346, 8858, 8970, 9148, 9149, 9155, 9213 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double e1544 = getMax(vRange);
            return Math.Max(e446, e1544);
        }
        [MyDescription("血糖调节异常", "8_15_1")]
        public double zzgj_xttjyc()
        {
            double e448 = info_LookUp(nutri_factor, 302, 40);
            double e449 = value_E(nutri_factor, 5618);
            double e450 = value_E(nutri_factor, 5619);
            double e451 = value_E(nutri_factor, 5621);
            double e452 = value_E(nutri_factor, 5616);
            double e453 = value_E(nutri_factor, 5622);
            double e454 = value_E(nutri_factor, 5765);
            List<double> mRange = new List<double> { e448, e449, e450, e451, e452, e453, e454 };
            double f448 = getMax(mRange);
            return f448;
        }
        [MyDescription("内分泌性糖尿病风险", "8_15_2")]
        public double zzgj_nfmxtlb()
        {
            double e449 = value_E(nutri_factor, 5618);
            return e449;
        }
        [MyDescription("医源性糖尿病风险", "8_15_3")]
        public double zzgj_yyxtlb()
        {
            double e450 = value_E(nutri_factor, 5619);

            return e450;
        }
        [MyDescription("隐性糖尿病风险", "8_15_4")]
        public double zzgj_yxtlb()
        {
            double e451 = value_E(nutri_factor, 5621);
            return e451;
        }

        [MyDescription("不稳定型糖尿病风险", "8_15_5")]
        public double zzgj_bwdxtlb()
        {
            double e452 = value_E(nutri_factor, 5616);
            return e452;
        }
        [MyDescription("多糖症风险", "8_15_6")]
        public double zzgj_dtzfx()
        {
            double e453 = value_E(nutri_factor, 5622);
            return e453;
        }
        [MyDescription("低血糖休克风险", "8_15_7")]
        public double zzgj_dxtxk()
        {
            double e454 = value_E(nutri_factor, 5765);
            return e454;
        }
        [MyDescription("高脂血症风险", "8_15_8")]
        public double zzgj_gxz()
        {
            double e455 = value_E(nutri_factor, 5735);
            return e455;
        }
        [MyDescription("低蛋白血症风险", "8_15_9")]
        public double zzgj_ddbxz()
        {
            double e456 = value_E(nutri_factor, 5749);
            return e456;
        }
        [MyDescription("痛风风险", "8_15_10")]
        public double zzgj_tf()
        {
            double e457 = value_E(nutri_factor, 2136);
            double e458 = value_E(nutri_factor, 5694);
            List<int> dRange = new List<int> { 287, 352, 408, 433, 447, 463, 895, 896, 1312, 2139, 3204, 3244, 3647, 4075, 5697, 5786, 7509 };
            List<double> vRange = new List<double>();
            for (int i = 0; i < dRange.Count; i++)
            {
                double d = value_D(nutri_factor, dRange[i] - 3);
                vRange.Add(d);
            }
            double f1673 = getMax(vRange);
            double g1673 = f1673 > max_value ? max_value : (f1673 < 0 ? 0 : f1673);
            double f457 = Math.Max(Math.Max(e457, e458), g1673);
            return f457;
        }
        [MyDescription("脱水风险", "8_15_11")]
        public double zzgj_ts()
        {
            double e459 = value_E(nutri_factor, 5610);
            return e459;
        }
        [MyDescription("水肿风险", "8_15_12")]
        public double zzgj_sz()
        {
            double e460 = value_E(nutri_factor, 5647);
            return e460;
        }

        [MyDescription("低血钾风险", "8_15_13")]
        public double zzgj_dxj()
        {
            double e461 = value_E(nutri_factor, 5745);
            return e461;
        }
        [MyDescription("低血钠风险", "8_15_14")]
        public double zzgj_dxn()
        {
            double e462 = value_E(nutri_factor, 5746);
            return e462;
        }
        [MyDescription("脑部疾病风险", "10_1_1")]
        public double zs_nbjb()
        {
            double e465 = value_E(nutri_factor, 6103);
            double e466 = value_E(nutri_factor, 1819);
            double e467 = value_E(nutri_factor, 5666);
            double e468 = value_E(nutri_factor, 5809);
            double e469 = value_E(nutri_factor, 5559);
            double e470 = value_E(nutri_factor, 5653);
            double e471 = value_E(nutri_factor, 1794);
            double e472 = value_E(nutri_factor, 5547);
            double e473 = value_E(nutri_factor, 5863);
            double e474 = value_E(nutri_factor, 5865);
            List<double> mRange = new List<double> { e465, e466, e467, e468, e469, e470, e471, e472, e473, e474 };
            double f465 = getMax(mRange);
            return f465;
        }
        [MyDescription("锥体外系功能异常", "10_1_2")]
        public double zs_ztwx()
        {
            double e467 = value_E(nutri_factor, 5666);
            return e467;
        }
        [MyDescription("脑膜炎风险", "10_1_3")]
        public double zs_nmy()
        {
            double e468 = value_E(nutri_factor, 5809);
            return e468;
        }
        [MyDescription("脑瘤风险", "10_1_4")]
        public double zs_nl()
        {
            double e469 = value_E(nutri_factor, 5559);
            return e469;
        }
        [MyDescription("脑炎风险", "10_1_5")]
        public double zs_ny()
        {
            double e470 = value_E(nutri_factor, 5653);
            return e470;
        }
        [MyDescription("基底节病变可能", "10_1_6")]
        public double zs_jdjbb()
        {
            double e471 = value_E(nutri_factor, 1794);
            double e472 = value_E(nutri_factor, 5547);
            double f471 = Math.Max(e471, e472);
            return f471;
        }
        [MyDescription("帕金森氏病风险", "10_1_7")]
        public double zs_pjss()
        {
            double e473 = value_E(nutri_factor, 5863);
            double e474 = value_E(nutri_factor, 5865);
            double f473 = Math.Max(e473, e474);
            return f473;
        }
        [MyDescription("臂丛神经异常", "10_2_1")]
        public double zw_bcsj()
        {
            double e476 = value_E(nerve_factor, 5806);
            double e477 = value_E(nerve_factor, 5558);
            double f476 = Math.Max(e476, e477);
            return f476;
        }
        [MyDescription("肌皮神经异常", "10_2_2")]
        public double zw_jpsj()
        {
            double e478 = value_E(nerve_factor, 5823);
            return e478;
        }
        [MyDescription("肋间神经异常", "10_2_3")]
        public double zw_ljsj()
        {
            double e479 = value_E(nerve_factor, 2626);
            return e479;
        }
        [MyDescription("胸段脊神经（肺）异常", "10_2_4")]
        public double zw_xdjsjf()
        {
            double e480 = value_E(nerve_factor, 2634);
            return e480;
        }
        [MyDescription("胸脊神经异常", "10_2_5")]
        public double zw_xjsj()
        {
            double e481 = value_E(nerve_factor, 2620);
            return e481;
        }
        [MyDescription("副交感神经异常", "10_2_6")]
        public double zw_fjgsj()
        {
            double e482 = value_E(nerve_factor, 4160);
            return e482;
        }
        [MyDescription("交感神经系统异常", "10_2_7")]
        public double zw_jgsjxt()
        {
            double e483 = value_E(nerve_factor, 5962);
            return e483;
        }
        [MyDescription("三叉神经异常", "10_2_8")]
        public double zw_szsj()
        {
            double e484 = value_E(nerve_factor, 2623);
            double e485 = value_E(nerve_factor, 5984);
            return Math.Max(e484, e485);
        }
        [MyDescription("滑车神经异常", "10_2_9")]
        public double zw_hcsj()
        {
            double e487 = value_E(nerve_factor, 5985);
            double e488 = value_E(nerve_factor, 2625);
            return Math.Max(e487, e488);
        }
        [MyDescription("股神经异常", "10_2_10")]
        public double zw_gsj()
        {
            double e489 = value_E(nerve_factor, 5671);
            double e490 = value_E(nerve_factor, 2621);
            return Math.Max(e489, e490);
        }
        [MyDescription("骶神经丛异常", "10_2_11")]
        public double zw_dsjc()
        {
            double e491 = value_E(nerve_factor, 5874);
            return e491;
        }

        [MyDescription("骶神经异常", "10_2_12")]
        public double zw_dsj()
        {
            double e492 = value_E(nerve_factor, 5914);
            double e493 = value_E(nerve_factor, 2635);
            return Math.Max(e492, e493);
        }

        [MyDescription("坐骨神经异常", "10_2_13")]
        public double zw_zgsj()
        {
            double e494 = value_E(nerve_factor, 5914);
            double e495 = value_E(nerve_factor, 2635);
            return Math.Max(e494, e495);
        }
        [MyDescription("腰椎神经异常", "10_2_14")]
        public double zw_yzsj()
        {
            double e496 = value_E(nerve_factor, 5756);
            return e496;
        }
        [MyDescription("视神经异常", "10_2_15")]
        public double zw_ssj()
        {
            double e497 = value_E(nerve_factor, 2632);
            double e498 = value_E(nerve_factor, 2592);
            double e499 = value_E(nerve_factor, 5846);
            double f497 = Math.Max(Math.Max(e497, e498), e499);
            return f497;
        }
        [MyDescription("听神经异常", "10_2_16")]
        public double zw_tsj()
        {
            double e500 = value_E(nerve_factor, 2612);
            double e501 = value_E(nerve_factor, 5535);
            double e502 = value_E(nerve_factor, 2646);
            double f500 = Math.Max(Math.Max(e500, e501), e502);
            return f500;
        }
        [MyDescription("胸段脊神经（心）异常", "10_2_17")]
        public double zw_xdjsj()
        {
            double e503 = value_E(nerve_factor, 2614);
            return e503;
        }
        [MyDescription("颈段脊神经异常", "10_2_18")]
        public double zw_jdjsj()
        {
            double e504 = value_E(nerve_factor, 2615);
            return e504;
        }
        [MyDescription("手及足相关脊神经异常", "10_2_19")]
        public double zw_sjzjsj()
        {
            double e505 = value_E(nerve_factor, 2617);
            return e505;
        }
        [MyDescription("腰背脊神经异常", "10_2_20")]
        public double zw_ybjsj()
        {
            double e506 = value_E(nerve_factor, 2619);
            return e506;
        }
        [MyDescription("舌咽神经异常", "10_2_21")]
        public double zw_sysj()
        {
            double e507 = value_E(nerve_factor, 2622);
            double e508 = value_E(nerve_factor, 2629);
            double e509 = value_E(nerve_factor, 2641);
            double e510 = value_E(nerve_factor, 2692);
            List<double> mRange = new List<double> { e507, e508, e509, e510 };
            double f507 = getMax(mRange);
            return f507;
        }
        [MyDescription("舌下神经异常", "10_2_22")]
        public double zw_sxsj()
        {
            double e511 = value_E(nerve_factor, 2624);
            double e512 = value_E(nerve_factor, 2640);
            double f511 = Math.Max(e511, e512);
            return f511;
        }
        [MyDescription("骶丛异常", "10_2_23")]
        public double zw_dcyc()
        {
            double e513 = value_E(nerve_factor, 2627);
            return e513;
        }
        [MyDescription("腰骶部脊神经异常", "10_2_24")]
        public double zw_ydbjsj()
        {
            double e514 = value_E(nerve_factor, 2628);
            return e514;
        }
        [MyDescription("颈丛异常", "10_2_25")]
        public double zw_jcsj()
        {
            double e515 = value_E(nerve_factor, 2630);
            return e515;
        }
        [MyDescription("嗅神经异常", "10_2_26")]
        public double zw_xsjyc()
        {
            double e516 = value_E(nerve_factor, 2631);
            return e516;
        }
        [MyDescription("胸段脊神经（脾、胰）异常", "10_2_27")]
        public double zw_xdjsjyc()
        {
            double e517 = value_E(nerve_factor, 2633);
            return e517;
        }
        [MyDescription("胸神经异常", "10_2_28")]
        public double zw_xsj()
        {
            double e518 = value_E(nerve_factor, 2639);
            return e518;
        }
        [MyDescription("面神经异常", "10_2_29")]
        public double zw_msj()
        {
            double e519 = value_E(nerve_factor, 2613);
            double e520 = value_E(nerve_factor, 2620);
            double e521 = value_E(nerve_factor, 5667);
            double f519 = Math.Max(Math.Max(e519, e520), e521);
            return f519;
        }
        [MyDescription("臂丛内侧束异常", "10_2_30")]
        public double zw_bcncs()
        {
            double e522 = value_E(nerve_factor, 2642);
            return e522;
        }
        [MyDescription("腰段脊神经（子宫）异常", "10_2_31")]
        public double zw_ydjsjzg()
        {
            return 0;
        }
        [MyDescription("腰段脊神经（阴道）异常", "10_2_32")]
        public double zw_ydjsjyd()
        {
            return 0;
        }
        [MyDescription("动眼神经异常", "10_2_33")]
        public double zw_dysj()
        {
            double e525 = value_E(nerve_factor, 5847);
            return e525;
        }
        [MyDescription("迷走神经异常", "10_2_34")]
        public double zw_mzsj()
        {
            double e526 = value_E(nerve_factor, 2645);
            double e527 = value_E(nerve_factor, 6005);
            double e528 = value_E(nerve_factor, 1836);
            double e529 = value_E(nerve_factor, 2638);
            List<double> mRange = new List<double> { e526, e527, e528, e529 };
            double f526 = getMax(mRange);
            return f526;
        }
        [MyDescription("外展神经异常", "10_2_35")]
        public double zw_wzsj()
        {
            double e530 = value_E(nerve_factor, 5451);
            double e531 = value_E(nerve_factor, 2637);
            return Math.Max(e530, e531);
        }
        [MyDescription("面神经瘫风险", "10_2_36")]
        public double zw_msjt()
        {
            double e532 = value_E(nerve_factor, 5668);
            return e532;
        }
        [MyDescription("皮质脊髓束功能异常", "10_2_37")]
        public double zw_pzjss()
        {
            double e515 = value_E(nerve_factor, 2630);
            return e515;

        }
        [MyDescription("脊髓侧索硬化风险", "10_2_38")]
        public double zw_jscsyh()
        {
            double e533 = value_E(nerve_factor, 5497);
            return e533;
        }
        [MyDescription("多发性神经炎风险", "10_2_39")]
        public double zw_dfxsjy()
        {
            double e534 = value_E(nerve_factor, 2809);
            return e534;
        }
        [MyDescription("多发性硬化风险", "10_2_40")]
        public double zw_dfxyh()
        {
            double e535 = value_E(nerve_factor, 2001);
            return e535;
        }
        [MyDescription("颅神经异常", "10_2_41")]
        public double zw_lsj()
        {
            double e536 = value_E(nerve_factor, 6101);
            return e536;
        }

        [MyDescription("下运动神经元异常", "10_3_1")]
        public double xb_xydsjy()
        {
            double e538 = value_E(nerve_factor, 5791);
            return e538;
        }
        [MyDescription("小脑功能失调", "10_4_1")]
        public double zzgj_xngn()
        {
            double e540 = value_E(nerve_factor, 5584);
            return e540;
        }
        [MyDescription("大脑功能异常", "10_4_2")]
        public double zzgj_dngn()
        {
            double e541 = value_E(nerve_factor, 5585);
            return e541;
        }
        [MyDescription("神经根压迫可能", "10_4_3")]
        public double zzgj_sjgyp()
        {
            double e542 = value_E(nerve_factor, 5837);
            return e542;
        }
        [MyDescription("神经系统损伤可能", "10_4_4")]
        public double zzgj_sjxtss()
        {
            double e543 = value_E(nerve_factor, 5839);
            return e543;
        }
        [MyDescription("神经痛可能", "10_4_5")]
        public double zzgj_sjt()
        {
            double e544 = value_E(nerve_factor, 2019);
            return e544;

        }
        [MyDescription("免疫力指数", "11_1_1")]
        public double myl_zs()
        {
            double c2686 = Double.Parse(infoList[15].Value);
            double d2686 = MathEx.RoundUp(Math.Abs(100 - c2686) / 12, 1);
            double e2686 = d2686 > max_value ? max_value : (d2686 < 0 ? 0 : d2686);
            
            List<double> dRange = new List<double> { myl_myxt(), myl_myqdb(), myl_jxyz(), myl_mxyz(), xx_xxgn(), xx_xxt(), lb_btt(), lb_jb(), lb_xb(), lb_lbl(), lb_lbxy(), p_pzgn(), gm_swgm(), gm_hfgm(), gm_gmxby(), gm_qtgmfy(), my_bdgr(), my_xjgr(), my_mjgr(), my_jhxgr(), my_zqzlfx(), my_fsjbkn(), my_ztmyxjb(), zzgj_fs(), zzgj_btxzd(), zzgj_btxy() };
            double avg = averageThree(dRange);
            double rtn = Math.Max(e2686, avg);
            return rtn;
        }
        [MyDescription("免疫系统异常", "11_1_2")]
        public double myl_myxt()
        {
            double e549 = value_E(immu_factor, 6056);
            double e550 = info_LookUp(immu_factor, 294, 40);
            double e551 = value_E(immu_factor, 5488);
            double e552 = value_E(immu_factor, 8883);
            double e553 = value_E(immu_factor, 5757);
            double e554 = value_E(immu_factor, 3015);
            double e555 = value_E(immu_factor, 6044);
            double e556 = info_LookUp(immu_factor, 308, 40);
            double e557 = value_E(immu_factor, 6047);
            double e558 = info_LookUp(immu_factor, 308, 40);
            double e560 = value_E(immu_factor, 6099);
            double e561 = value_E(immu_factor, 1820);
            double e562 = value_E(immu_factor, 2543);
            double e564 = value_E(immu_factor, 1827);
            double e565 = info_LookUp(immu_factor, 327, 40);
            double e566 = value_E(immu_factor, 1813);
            double e567 = value_E(immu_factor, 6085);
            double e568 = value_E(immu_factor, 1990);
            double e569 =  value_E(immu_factor, 1876);
            double e570 = value_E(immu_factor, 5797);
            double e572 = value_E(immu_factor,1821);
            double e573 = value_E(immu_factor, 6086);
            double e575 = value_E(immu_factor, 6800);
            double e576 = info_LookUp(immu_factor, 298, 50);
            double e577 = value_E(immu_factor, 5707);
            double e578 = info_LookUp(immu_factor, 298, 40);
            double e579 = value_E(immu_factor, 5487);
            double e580 = info_LookUp(immu_factor, 298, 40);
            double e581 = value_E(immu_factor, 3326);
            double e582 = info_LookUp(immu_factor, 298, 48);
            double e584 = value_E(immu_factor, 6052);
            double e585 = info_LookUp(immu_factor, 313, 46);
            double e586 = value_E(immu_factor, 5538);
            double e587 = info_LookUp(immu_factor, 313, 40);
            double e588 = value_E(immu_factor, 2382);
            double e589 = value_E(immu_factor, 6054);
            double e590 = info_LookUp(immu_factor, 313, 42);
            double e591 = value_E(immu_factor, 1998);
            double e592 = value_E(immu_factor, 6055);
            double e593 = info_LookUp(immu_factor, 313, 43);
            double e594 = value_E(immu_factor, 5571);
            double e595 = info_LookUp(immu_factor, 315, 40);
            double e596 = value_E(immu_factor, 6089);
            double e597 = value_E(immu_factor, 5537);
            double e598 = value_E(immu_factor, 5795);
            double e599 = value_E(immu_factor, 5912);
            double e601 = value_E(immu_factor, 5672);
            double e602 = value_E(immu_factor, 1801);
            double e603 = value_E(immu_factor, 5469);
            double e604 = value_E(immu_factor, 5978);
            List<double> dRange = new List<double> {e549,e550,e551,e552,e553,e554,e555,e556,e557,e558,e560,e561,e562,e564,e565,e566,e567,e568,e569,e570,e572,e573,e575,e576,e577,e578,e579,e580,e581,e582,e584,e585,e586,e587,e588,e589,e590,e591,e592,e593,e594,e595,e596,e597,e598,e599,e601,e602,e603,e604 };
            double f549 = getMax(dRange);
            return f549;
        }
        [MyDescription("免疫球蛋白异常", "11_1_3")]
        public double myl_myqdb()
        {
            double e553 = value_E(immu_factor, 5757);
            double e554 = value_E(immu_factor, 3015);
            return Math.Max(e553, e554);
        }
        [MyDescription("急性炎症可能", "11_1_4")]
        public double myl_jxyz()
        {
            double e555 = value_E(immu_factor, 6044);
            double e556 = info_LookUp(immu_factor, 308, 40);
            return Math.Max(e555, e556);
        }
        [MyDescription("慢性炎症可能", "11_1_5")]
        public double myl_mxyz()
        {
            double e557 = value_E(immu_factor, 6047);
            double e558 = info_LookUp(immu_factor, 308, 40);
            return Math.Max(e557, e558);
        }
        [MyDescription("胸腺功能异常", "11_3_1")]
        public double xx_xxgn()
        {
            double e560 = value_E(immu_factor, 6099);
            double e561 = value_E(immu_factor, 1820);
            return Math.Max(e560, e561);
        }
        [MyDescription("胸腺肽异常", "11_3_2")]
        public double xx_xxt()
        {
            double e562 = value_E(immu_factor, 2543);
            return e562;
        }
        [MyDescription("扁桃体功能异常", "11_4_1")]
        public double lb_btt()
        {
            double e564 = value_E(immu_factor, 1827);
            return e564;
        }
        [MyDescription("淋巴疾病风险", "11_4_2")]
        public double lb_jb()
        {
            double e565 = info_LookUp(immu_factor, 327, 40);
            double e566 = value_E(immu_factor, 1813);
            double e567 = value_E(immu_factor, 6085);
            double e568 = value_E(immu_factor, 1990);
            double e569 = value_E(immu_factor, 1876);
            double e570 = value_E(immu_factor, 5797);
            List<double> dRange = new List<double> { e565, e566, e567, e568, e569, e570 };
            double f565 = getMax(dRange);
            return f565;
        }
        [MyDescription("淋巴细胞异常", "11_4_3")]
        public double lb_xb()
        {
            double e568 = value_E(immu_factor, 1990);
            return e568;
        }
        [MyDescription("淋巴瘤风险", "11_4_4")]
        public double lb_lbl()
        {
            double e569 = value_E(immu_factor, 1876);
            return e569;
        }
        [MyDescription("淋巴腺炎可能", "11_4_5")]
        public double lb_lbxy()
        {
            double e570 = value_E(immu_factor, 5797);
            return e570;
        }
        [MyDescription("脾脏功能异常", "11_5_1")]
        public double p_pzgn()
        {
            double e572 = value_E(immu_factor, 1821);
            double e573 = value_E(immu_factor, 6086);
            return Math.Max(e573, e572);
        }
        [MyDescription("食物过敏风险", "11_6_1")]
        public double gm_swgm()
        {
            double e581 = value_E(immu_factor, 3326);
            double e582 = info_LookUp(immu_factor, 298, 48);
            return Math.Max(e581, e582);

        }
        [MyDescription("花粉过敏可能", "11_6_2")]
        public double gm_hfgm()
        {
            double e575 = value_E(immu_factor, 6800);
            double e576 = info_LookUp(immu_factor, 298, 50);
            return Math.Max(e575, e576);
        }
        [MyDescription("过敏性鼻炎可能", "11_6_3")]
        public double gm_gmxby()
        {
            double e577 = value_E(immu_factor, 5707);
            double e578 = info_LookUp(immu_factor, 298, 40);
            return Math.Max(e577, e578);
        }
        [MyDescription("其它过敏反应风险", "11_6_4")]
        public double gm_qtgmfy()
        {
            double e579 = value_E(immu_factor, 5487);
            double e580 = info_LookUp(immu_factor, 298, 40);
            return Math.Max(e579, e580);
        }
        [MyDescription("病毒感染可能", "11_8_1")]
        public double my_bdgr() 
        {
            double e584 = value_E(immu_factor, 6052);
            double e585 = info_LookUp(immu_factor, 313, 46);
            return Math.Max(e584, e585);
        }
        [MyDescription("细菌感染可能", "11_8_2")]
        public double my_xjgr()
        {
            double e586 = value_E(immu_factor, 5538);
            double e587 = info_LookUp(immu_factor, 313, 40);
            return Math.Max(e586, e587);
        }
        [MyDescription("霉菌感染可能", "11_8_3")]
        public double my_mjgr()
        {
            double e588 = value_E(immu_factor, 2382);
            double e589 = value_E(immu_factor, 6054);
            double e590 = info_LookUp(immu_factor, 313, 42);
            double e591 = value_E(immu_factor, 1998);
            return Math.Max(Math.Max(e588, e589), Math.Max(e590, e591));
        }
        [MyDescription("机会性感染可能", "11_8_4")]
        public double my_jhxgr()
        {
            double e592 = value_E(immu_factor, 6055);
            double e593 = info_LookUp(immu_factor, 313, 43);
            return Math.Max(e592, e593);
        }
        [MyDescription("早期肿瘤风险", "11_8_5")]
        public double my_zqzlfx()
        {
            double e594 = value_E(immu_factor, 5571);
            return e594;
        }
        [MyDescription("风湿疾病可能", "11_8_6")]
        public double my_fsjbkn()
        {
            double e596 = value_E(immu_factor, 6089);
            return e596;
        }
        [MyDescription("自体免疫性疾病风险", "11_8_7")]
        public double my_ztmyxjb()
        {
            double e597 = value_E(immu_factor, 5537);
            double e598 = value_E(immu_factor, 5795);
            double e599 = value_E(immu_factor, 5912);
            return Math.Max(e597, Math.Max(e598, e599));
        }
        [MyDescription("发烧可能", "11_9_1")]
        public double zzgj_fs()
        {
            double e601 = value_E(immu_factor, 5672);
            return e601;
        }
        [MyDescription("扁桃腺肿大可能", "11_9_2")]
        public double zzgj_btxzd()
        {
            double e602 = value_E(immu_factor, 1801);
            double e603 = value_E(immu_factor, 5469);
            return Math.Max(e602, e603);
        }
        [MyDescription("扁桃腺炎可能", "11_9_3")]
        public double zzgj_btxy()
        {
            double e604 = value_E(immu_factor, 5978);
            return e604;
        }
        [MyDescription("颈椎异常", "12_1_1")]
        public double jj_jzyc()
        {
            double e607 = value_E2(move_factor, 4139);
            double e608 = value_E2(move_factor, 3581);
            double e609 = value_E2(move_factor, 3582);
            double e610 = value_E2(move_factor, 3583);
            double e611 = value_E2(move_factor, 3611);
            double e612 = value_E2(move_factor, 3584);
            double e613 = value_E2(move_factor, 3585);
            double e614 = value_E2(move_factor, 3586);
            List<double> vRange = new List<double> { e607, e608, e609, e610, e611, e612, e613, e614 };
            double f607 = getMax(vRange);
            return f607;
        }
        [MyDescription("颈椎 C1 异常", "12_1_2")]
        public double jj_C1()
        {
            double e608 = value_E2(move_factor, 3581);
            return e608;
        }
        [MyDescription("颈椎 C2 异常", "12_1_3")]
        public double jj_C2()
        {
            double e609 = value_E2(move_factor, 3582);
            return e609;
        }
        [MyDescription("颈椎 C3 异常", "12_1_4")]
        public double jj_C3()
        {
            double e610 = value_E2(move_factor, 3583);
            return e610;
        }
        [MyDescription("颈椎 C4 异常", "12_1_5")]
        public double jj_C4()
        {
            double e611 = value_E2(move_factor, 3611);
            return e611;
        }
        [MyDescription("颈椎 C5 异常", "12_1_6")]
        public double jj_C5()
        {
            double e612 = value_E2(move_factor, 3584);
            return e612;
        }
        [MyDescription("颈椎 C6 异常", "12_1_7")]
        public double jj_C6()
        {
            double e613 = value_E2(move_factor, 3585);
            return e613;
        }
        [MyDescription("颈椎 C7 异常", "12_1_8")]
        public double jj_C7()
        {
            double e614 = value_E2(move_factor, 3586);
            return e614;
        }

        [MyDescription("胸椎异常", "12_2_1")]
        public double xz_yc()
        {
            double e616 = value_E2(move_factor, 4140);
            double e617 = value_E2(move_factor, 3587);
            double e618 = value_E2(move_factor, 3588);
            double e619 = value_E2(move_factor, 3589);
            double e620 = value_E2(move_factor, 3590);
            double e621 = value_E2(move_factor, 3591);
            double e622 = value_E2(move_factor, 3592);
            double e623 = value_E2(move_factor, 3593);
            double e624 = value_E2(move_factor, 3594);
            double e625 = value_E2(move_factor, 3595);
            double e626 = value_E2(move_factor, 3596);
            double e627 = value_E2(move_factor, 3597);
            double e628 = value_E2(move_factor, 3598);
            List<double> vRange = new List<double> { e616, e617, e618, e619, e620, e621, e622, e623, e624, e625, e626, e627, e628 };
            double f616 = getMax(vRange);
            return f616;
        }
        [MyDescription("胸椎 T1 异常", "12_2_2")]
        public double xz_T1()
        {
            double e617 = value_E2(move_factor, 3587);
            return e617;
        }
        [MyDescription("胸椎 T2 异常", "12_2_3")]
        public double xz_T2()
        {
            double e618 = value_E2(move_factor, 3588);
            return e618;
        }
        [MyDescription("胸椎 T3 异常", "12_2_4")]
        public double xz_T3()
        {
            double e619 = value_E2(move_factor, 3589);
            return e619;
        }
        [MyDescription("胸椎 T4 异常", "12_2_5")]
        public double xz_T4()
        {
            double e620 = value_E2(move_factor, 3590);
            return e620;
        }
        [MyDescription("胸椎 T5 异常", "12_2_6")]
        public double xz_T5()
        {
            double e621 = value_E2(move_factor, 3591);
            return e621;
        }
        [MyDescription("胸椎 T6 异常", "12_2_7")]
        public double xz_T6()
        {
            double e622 = value_E2(move_factor, 3592);
            return e622;
        }
        [MyDescription("胸椎 T7 异常", "12_2_8")]
        public double xz_T7()
        {
            double e623 = value_E2(move_factor, 3593);
            return e623;
        }
        [MyDescription("胸椎 T8 异常", "12_2_9")]
        public double xz_T8()
        {
            double e624 = value_E2(move_factor, 3594);
            return e624;
        }
        [MyDescription("胸椎 T9 异常", "12_2_10")]
        public double xz_T9()
        {
            double e625 = value_E2(move_factor, 3595);
            return e625;
        }
        [MyDescription("胸椎 T10 异常", "12_2_11")]
        public double xz_T10()
        {
            double e626 = value_E2(move_factor, 3596);
            return e626;
        }
        [MyDescription("胸椎 T11 异常", "12_2_12")]
        public double xz_T11()
        {
            double e627 = value_E2(move_factor, 3597);
            return e627;
        }
        [MyDescription("胸椎 T12 异常", "12_2_13")]
        public double xz_T12()
        {
            double e628 = value_E2(move_factor, 3598);
            return e628;
        }
        [MyDescription("腰椎异常", "12_3_1")]
        public double yz_yc()
        {
            double e630 = value_E2(move_factor, 4138);
            double e631 = value_E2(move_factor, 3599);
            double e632 = value_E2(move_factor, 3600);
            double e633 = value_E2(move_factor, 3601);
            double e634 = value_E2(move_factor, 3602);
            double e635 = value_E2(move_factor, 3603);
            double e636 = value_E2(move_factor, 5721);
            List<double> vRange = new List<double> { e630, e631, e632, e633, e634, e635, e636 };
            double f630 = getMax(vRange);
            return f630;
        }
        [MyDescription("腰椎 L1 异常", "12_3_2")]
        public double yz_L1()
        {
            double e631 = value_E2(move_factor, 3599);
            return e631;
        }
        [MyDescription("腰椎 L2 异常", "12_3_3")]
        public double yz_L2()
        {
            double e632 = value_E2(move_factor, 3600);
            return e632;
        }
        [MyDescription("腰椎 L3 异常", "12_3_4")]
        public double yz_L3()
        {
            double e633 = value_E2(move_factor, 3601);
            return e633;
        }
        [MyDescription("腰椎 L4 异常", "12_3_5")]
        public double yz_L4()
        {
            double e634 = value_E2(move_factor, 3602);
            return e634;
        }
        [MyDescription("腰椎 L5 异常", "12_3_6")]
        public double yz_L5()
        {
            double e635 = value_E2(move_factor, 3603);
            return e635;
        }
        [MyDescription("腰椎间盘突出", "12_3_7")]
        public double yz_yzjptc()
        {
            double e636 = value_E2(move_factor, 5721);
            return e636;
        }
        [MyDescription("骶骨异常", "12_4_1")]
        public double zwb_zgyc()
        {
            double e638 = value_E2(move_factor, 3604);
            return e638;
        }
        [MyDescription("骶椎异常", "12_4_2")]
        public double zwb_zzyc()
        {
            double e639 = value_E2(move_factor, 4141);
            return e639;
        }
        [MyDescription("骶髂关节损伤可能", "12_4_3")]
        public double zwb_gjss()
        {
            double e640 = value_E2(move_factor, 5915);
            double e641 = value_E2(move_factor, 3605);
            double f640 = Math.Max(e640, e641);
            return f640;
        }
        [MyDescription("上臂异常", "12_5_1")]
        public double sz_sbyc()
        {
            double e643 = value_E2(move_factor, 5552);
            return e643;
        }
        [MyDescription("肩胛骨异常", "12_5_2")]
        public double sz_jjgyc()
        {
            double e644 = value_E2(move_factor, 4145);
            return e644;
        }
        [MyDescription("上臂骨、肱骨异常", "12_5_3")]
        public double sz_sbg()
        {
            double e645 = value_E2(move_factor, 4147);
            return e645;
        }
        [MyDescription("下臂骨、挠骨、尺骨异常", "12_5_4")]
        public double sz_xbg()
        {
            double e646 = value_E2(move_factor, 4148);
            return e646;
        }
        [MyDescription("手骨异常", "12_5_5")]
        public double sz_sgyc()
        {
            double e647 = value_E2(move_factor, 4135);
            return e647;
        }
        [MyDescription("手腕骨异常", "12_5_6")]
        public double sz_swgyc()
        {
            double e648 = value_E2(move_factor, 4149);
            return e648;
        }
        [MyDescription("腕管综合征可能", "12_5_7")]
        public double sz_wgzhz()
        {
            double e649 = value_E2(move_factor, 5579);
            return e649;
        }

        [MyDescription("髋关节异常", "12_6_1")]
        public double xz_kgjyc()
        {
            double e651= value_E2(move_factor, 3608);
            return e651;
        }
        [MyDescription("髋骨异常", "12_6_2")]
        public double xz_kgyc()
        {
            double e652 = value_E2(move_factor, 4146);
            return e652;
        }
        [MyDescription("足骨异常", "12_6_3")]
        public double xz_zgyc()
        {
            double e653 = value_E2(move_factor, 3620);
            double e654 = value_E2(move_factor, 4137);
            return Math.Max(e653,e654);
        }
        [MyDescription("踝骨异常", "12_6_4")]
        public double xz_hgyc()
        {
            double e655 = value_E2(move_factor, 4150);
            return e655;
        }
        [MyDescription("大腿异常", "12_6_5")]
        public double xz_dtyc()
        {
            double e656 = value_E2(move_factor, 4151);
            return e656;
        }
        [MyDescription("小腿异常", "12_6_6")]
        public double xz_xtyc()
        {
            double e657 = value_E2(move_factor, 4152);
            return e657;
        }
        [MyDescription("脚踝异常", "12_6_7")]
        public double xz_jhyc()
        {
            double e658 = value_E2(move_factor, 5508);
            return e658;
        }
        [MyDescription("下肢异常", "12_6_8")]
        public double xz_xzyc()
        {
            double e659 = value_E2(move_factor, 5790);
            return e659;
        }
        [MyDescription("髋脱位可能", "12_6_9")]
        public double xz_ktw()
        {
            double e660 = value_E2(move_factor, 5728);
            return e660;
        }
        [MyDescription("髋关节损伤可能", "12_6_10")]
        public double xz_kgjss()
        {
            double e661 = value_E2(move_factor, 5729);
            return e661;
        }
        [MyDescription("膝盖损伤可能", "12_6_11")]
        public double xz_xgss()
        {
            double e662 = value_E2(move_factor, 5775);
            return e662;
        }
        [MyDescription("足部损伤可能", "12_6_12")]
        public double xz_zbss()
        {
            double e663 = value_E2(move_factor, 5676);
            return e663;
        }
        [MyDescription("静脉曲张可能", "12_6_13")]
        public double xz_jmqz()
        {
            double e664 = value_E2(move_factor, 6006);
            return e664;
        }

        /// <summary>
        /// 计算最大值
        /// </summary>
        /// <param name="range">要取最大值的所有数字的集合</param>
        /// <returns></returns>
        private double getMax(List<double> range)
        {
            double rtn = 0;
            rtn = range[0];
            for (int i = 1; i < range.Count; i++)
            {
                rtn = Math.Max(rtn, range[i]);
            }
            return rtn;
        }

        private double getNoMore(double max,double value)
        {
            double rtn = 0;
            if (value > max)
            {
                Random rd = new Random();
                double dResult;
                dResult = rd.NextDouble();
                rtn = Math.Round(value - 1 + dResult, 1);
            }
            else
            {
                rtn = value;
            }
            return rtn;
            
        }

        /// <summary>
        /// 计算D列的值
        /// </summary>
        /// <param name="facotr"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private double value_D(int factor, int index)
        {
            double c = Double.Parse(matrixList[index].Value);
            double d = MathEx.RoundUp(Math.Abs(75 - c) / base_value * factor, 1);
            return d;
        }

        private double value_D2(int factor, int index)
        {
            double c = Double.Parse(matrixList[index].Value);
            double d = MathEx.RoundUp(Math.Abs(75 - c) / (base_value-3) * factor, 1);
            return d;
        }

        private double info_LookUp(int factor, int index, int abs)
        {
            double c = Double.Parse(infoList[index].Value);
            double d = MathEx.RoundUp(Math.Abs(abs - c) / base_value * factor, 1);
            double e = d > max_value ? max_value : (d < 0 ? 0 : d);
            return e;
        }
        /// <summary>
        /// 计算第E列的值
        /// </summary>
        /// <param name="factor"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private double value_E(int factor, int index)
        {
            double c1 = Double.Parse(matrixList[index].Value);
            double d1 = MathEx.RoundUp(Math.Abs(75 - c1) / base_value * factor, 1);
            double e1 = d1 > max_value ? max_value : (d1 < 0 ? 0 : d1);
            return e1;
        }

        private double value_E2(int factor, int index)
        {
            double c1 = Double.Parse(matrixList[index].Value);
            double d1 = MathEx.RoundUp(Math.Abs(75 - c1) / (base_value-3) * factor, 1);
            double e1 = d1 > max_value ? max_value : (d1 < 0 ? 0 : d1);
            return e1;
        }

        private double averageThree(List<double> list)
        {
            double one = list.Max();
            list.Remove(one);
            double two = list.Max();
            list.Remove(two);
            double three = list.Max();
            double rtn = (one + two + three) / 3;
            rtn = Math.Round(rtn, 2);
            return rtn;
        }

    }


}
