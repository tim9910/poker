using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace poker
{
    
    public partial class frmPoker : Form
    {
        PictureBox[] pic = new PictureBox[5];
        int[] allPoker = new int[52];
        int[] playerPoker = new int[5];
        int[] poker = new int[5];
        ToolTip toolTip = null;

        public frmPoker()
        {
            InitializeComponent();
            //customize button image
            // 押注按鈕
            btnDet.Image = GetImage("money4");
            btnDet.Text = "";
            btnDet.FlatStyle = FlatStyle.Flat;//去除按鈕邊框
            btnDet.ImageAlign = ContentAlignment.MiddleCenter;//圖片置中
            btnDet.FlatAppearance.BorderSize = 0; 
            btnDet.BackColor = Color.Transparent; //按鈕背景透明
            btnDet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent; //按下時背景透明
            btnDet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnDet.MouseEnter += (sender, e) =>
            {
                btnDet.Image = ResizeImage(GetImage("money4"), new Size(48, 48));
            };

            btnDet.MouseLeave += (sender, e) =>
            {
                btnDet.Image = ResizeImage(GetImage("money4"), new Size(44, 44));
            };
            btnDet.Enabled = true;

            //發牌按鈕
            btnDealCard.Image = GetImage("dealcard");
            btnDealCard.Text = "";
            btnDealCard.FlatStyle = FlatStyle.Flat;//去除按鈕邊框
            btnDealCard.ImageAlign = ContentAlignment.MiddleCenter;//圖片置中
            btnDealCard.FlatAppearance.BorderSize = 0;
            btnDealCard.BackColor = Color.Transparent; //按鈕背景透明
            btnDealCard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent; //按下時背景透明
            btnDealCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnDealCard.MouseEnter += (sender, e) =>
            {
                btnDealCard.Image = ResizeImage(GetImage("dealcard"), new Size(48, 48));
            };

            btnDealCard.MouseLeave += (sender, e) =>
            {
                btnDealCard.Image = ResizeImage(GetImage("dealcard"), new Size(44, 44));
            };

            //換牌按鈕
            btnChangeCard.Image = GetImage("changecard");
            btnChangeCard.Text = "";
            btnChangeCard.FlatStyle = FlatStyle.Flat;//去除按鈕邊框
            btnChangeCard.ImageAlign = ContentAlignment.MiddleCenter;//圖片置中
            btnChangeCard.FlatAppearance.BorderSize = 0;
            btnChangeCard.BackColor = Color.Transparent; //按鈕背景透明
            btnChangeCard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent; //按下時背景透明
            btnChangeCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnChangeCard.MouseEnter += (sender, e) =>
            {
                btnChangeCard.Image = ResizeImage(GetImage("changecard"), new Size(48, 48));
            };

            btnChangeCard.MouseLeave += (sender, e) =>
            {
                btnChangeCard.Image = ResizeImage(GetImage("changecard"), new Size(44, 44));
            };


            //判斷牌型按鈕
            btnCheck.Image = GetImage("check");
            btnCheck.Text = "";
            btnCheck.FlatStyle = FlatStyle.Flat;//去除按鈕邊框
            btnCheck.ImageAlign = ContentAlignment.MiddleCenter;//圖片置中
            btnCheck.FlatAppearance.BorderSize = 0;
            btnCheck.BackColor = Color.Transparent; //按鈕背景透明
            btnCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent; //按下時背景透明
            btnCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnCheck.MouseEnter += (sender, e) =>
            {
                btnCheck.Image = ResizeImage(GetImage("check"), new Size(48, 48));
            };

            btnCheck.MouseLeave += (sender, e) =>
            {
                btnCheck.Image = ResizeImage(GetImage("check"), new Size(44, 44));
            };

            InitializePoker();
        }

        private Image ResizeImage(Image img, Size size)
        {
            return new Bitmap(img, size);
        }


        private void initToolTip()
        {
            toolTip = new ToolTip();
            toolTip.SetToolTip(txtDet, "押注金額 > 0 且 <= 總資金");
            toolTip.SetToolTip(btnDet, "押注金額");
            toolTip.SetToolTip(btnDealCard, "發牌");
            toolTip.SetToolTip(btnChangeCard, "換牌");
            toolTip.SetToolTip(btnCheck, "判斷牌型");
        }
        private void InitializePoker()
        {
            // 動態產生5張牌
            for (int i = 0; i < 5; i++)
            {
                pic[i] = new PictureBox();
                pic[i].Image = GetImage("back");
                pic[i].Name = "pic" + i;
                pic[i].SizeMode = PictureBoxSizeMode.AutoSize;
                pic[i].Top = 30;
                pic[i].Left = 10 + ((pic[i].Width + 10) * i);
                pic[i].Visible = true;
                pic[i].Enabled = false;//發牌之前，關閉pic[i]的事件，以免誤按
                pic[i].Tag = "back";//記錄初始狀態為牌背
                // 將pic 丟至到grpPorker內
                this.grpPoker.Controls.Add(pic[i]);
                pic[i].MouseClick += new MouseEventHandler(pic_Click);
            }
            initToolTip();
            //btnDealCard.Enabled = true;
        }


        private void pic_Click(object sender, MouseEventArgs e)
        {
            //PictureBox pic = (PictureBox)sender;
            //MessageBox.Show("你選擇了" + pic.Name);
            PictureBox pic = (PictureBox)sender;
            // 取得pic 的索引值
            int index = int.Parse(pic.Name.Replace("pic", ""));
            // 如果pic 的Tag 為back，則將顯示撲克牌
            if (pic.Tag.ToString() == "back")
            {
                pic.Tag = "front";
                pic.Image = GetImage("pic" + (allPoker[index] + 1));
            }
            else
            {
                pic.Tag = "back";
                pic.Image = GetImage("back");
            }
        }

        private void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < allPoker.Length; i++) 
            {
                int r = rand.Next(allPoker.Length); // 產生0~51的亂數
                int temp = allPoker[r];
                allPoker[r] = allPoker[0];
                allPoker[0] = temp;
            }
        }

        private async void btnDealCard_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";// 清空結果

            // 先將牌面蓋掉
            for (int i = 0; i < 5; i++)
            {
                pic[i].Image = GetImage("back");
            }
            // 初始化52張牌
            for (int i = 0; i < 52; i++)
            {
                allPoker[i] = i;
            }
            // 洗牌
            Shuffle();            
            await Task.Delay(500);// 暫停500ms(避免發牌太快，看不清楚)

            // 發牌
            for (int i = 0; i < 5; i++)
            {
                pic[i].Image = GetImage("pic" + (allPoker[i] + 1));
                playerPoker[i] = allPoker[i];//記錄目的牌號
                pic[i].Enabled = true;// 發牌後，啟用所有牌 pic[i] 的點擊事件
                pic[i].Tag = "front";//設定目前的牌已翻開
            }
            btnChangeCard.Enabled = true;// 發完牌後，開啟換牌按鈕
        }

        private void btnChangeCard_Click(object sender, EventArgs e)
        {
            int cardIndex = 5;  // 從第6張牌開始發牌
            for (int i = 0; i < pic.Length; i++)
            {
                if (pic[i].Tag.ToString() == "back")
                {
                    playerPoker[i] = allPoker[cardIndex]; // 從洗好的牌堆中取出下一張牌
                    pic[i].Image = GetImage("pic" + (playerPoker[i] + 1));
                    pic[i].Tag = "front";
                    cardIndex++;
                }
            }
            // 禁用所有牌的點擊事件
            for (int i = 0; i < pic.Length; i++)
            {//換牌只能一次，換完牌後就不能再換了，所以不管有沒有換牌，都要禁用所有牌的點擊事件
                pic[i].Enabled = false;
            }
            btnChangeCard.Enabled = false; // 停用換牌按鈕
            btnCheck.Enabled = true; //啟用判斷牌型按鈕
        }

        private Image GetImage(string name)
        {
            return Properties.Resources.ResourceManager.GetObject(name) as Image;
        }


        ///顯示五張撲克牌到桌面上
        private void ShowCards()
        {
            for (int i = 0; i < 5; i++)
            {
                pic[i].Image = this.GetImage($"pic{playerPoker[i] + 1}");
            }
        }

        private async void frmPoker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnDealCard.Enabled == false)
            {
                switch ((int)e.KeyChar)
                {
                    case 113: // q鍵
                              // 同花大順
                        playerPoker[0] = 51;
                        playerPoker[1] = 47;
                        playerPoker[2] = 43;
                        playerPoker[3] = 39;
                        playerPoker[4] = 3;
                        break;
                    case 119: // w鍵
                              // 同花順
                        playerPoker[0] = 37;
                        playerPoker[1] = 33;
                        playerPoker[2] = 29;
                        playerPoker[3] = 25;
                        playerPoker[4] = 21;
                        break;
                    case 101: // e鍵
                              // 同花
                        playerPoker[0] = 50;
                        playerPoker[1] = 38;
                        playerPoker[2] = 34;
                        playerPoker[3] = 22;
                        playerPoker[4] = 18;
                        break;
                    case 114: // r鍵
                              // 鐵支
                        playerPoker[0] = 48;
                        playerPoker[1] = 39;
                        playerPoker[2] = 38;
                        playerPoker[3] = 37;
                        playerPoker[4] = 36;
                        break;
                    case 116: // t鍵
                              // 葫蘆
                        playerPoker[0] = 30;
                        playerPoker[1] = 29;
                        playerPoker[2] = 6;
                        playerPoker[3] = 5;
                        playerPoker[4] = 4;
                        break;
                    case 121: // y鍵
                              // 三條
                        playerPoker[0] = 48;
                        playerPoker[1] = 39;
                        playerPoker[2] = 15;
                        playerPoker[3] = 14;
                        playerPoker[4] = 13;
                        break;

                    case 97: // a鍵
                              // 順子
                        playerPoker[0] = 34;
                        playerPoker[1] = 28;
                        playerPoker[2] = 24;
                        playerPoker[3] = 20;
                        playerPoker[4] = 16;
                        break;

                    case 115: // s鍵
                             // 二對  
                        playerPoker[0] = 45;
                        playerPoker[1] = 46;
                        playerPoker[2] = 13;
                        playerPoker[3] = 14;
                        playerPoker[4] = 16;
                        break;

                    case 100: // d鍵
                             // 一對
                        playerPoker[0] = 34;
                        playerPoker[1] = 28;
                        playerPoker[2] = 24;
                        playerPoker[3] = 13;
                        playerPoker[4] = 14;
                        break;
                }
                // 顯示五張撲克牌到桌面上
                if (e.KeyChar == 113 || e.KeyChar == 119 || e.KeyChar == 101 || e.KeyChar == 114 || e.KeyChar == 116 || e.KeyChar == 121 || e.KeyChar == 97 || e.KeyChar == 115 || e.KeyChar == 100)
                {
                    //蓋牌
                    for (int i = 0; i < 5; i++)
                    {
                        pic[i].Image = GetImage("back");
                        pic[i].Name = "pic" + i;
                    }

                    await Task.Delay(500);// 暫停500ms

                    ShowCards();
                    CheckPoker();
                    btnCheck.Enabled = true;
                }

            }
        }

        private (string, string) CheckPoker()
        {
            btnCheck.Enabled = false;
            btnDealCard.Enabled = false;
            // 判斷牌型
            string[] colorList = { "梅花", "方塊", "愛心", "黑桃" };
            string[] pointList = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            // 統計color 和point 出現次數
            int[] colorCount = new int[4];
            int[] pointCount = new int[13];

            // 計錄目前五張撲克牌的花色和點數的陣列
            int[] pokerColor = new int[5];
            int[] pokerPoint = new int[5];
            // 將每張牌的顏色和點數分別存入pokerColor和pokerPoint陣列
            for (int i = 0; i < 5; i++)
            {
                pokerColor[i] = playerPoker[i] % 4;
                pokerPoint[i] = playerPoker[i] / 4;
            }
            //統計 color 和 point 出現次數
            for (int i = 0; i < 5; i++)
            {
                int color = pokerColor[i];
                int point = pokerPoint[i];
                colorCount[color]++;
                pointCount[point]++;
            }
            // 排序colorCount和pointCount由大到小
            Array.Sort(colorCount, colorList);
            Array.Reverse(colorCount);
            Array.Reverse(colorList);
            Array.Sort(pointCount, pointList);
            Array.Reverse(pointCount);
            Array.Reverse(pointList);


            string result = "";
            // 判斷是否為同花
            bool isFlush = (colorCount[0] == 5);
            // 判斷是否為五張單張
            bool isSingle = (pointCount[0] == 1 && pointCount[1] == 1 && pointCount[2] == 1 && pointCount[3] == 1 && pointCount[4] == 1);
            // 判斷是否為差四
            bool isDiffFout = (pokerPoint.Max() - pokerPoint.Min() == 4);
            // 判斷是否為大順
            bool isRoyal = pokerPoint.Contains(0) && pokerPoint.Contains(9) && pokerPoint.Contains(10) && pokerPoint.Contains(11) && pokerPoint.Contains(12);
            // 判斷是否為同花大順
            bool isRoyalisFlush = isFlush && isRoyal;
            // 判斷是否為同花順
            bool isStraightFlush = isFlush && isSingle && isDiffFout;
            // 判斷是否為順子
            bool isStraight = isSingle && (isDiffFout || isRoyal);
            // 判斷是否為鐵支
            bool isFourOfAKind = (pointCount[0] == 4);
            // 判斷是否為葫蘆
            bool isFullHouse = (pointCount[0] == 3 && pointCount[1] == 2);
            // 判斷是否為三條
            bool isThreeOfAKind = (pointCount[0] == 3 && pointCount[1] == 1);
            // 判斷是否為兩對
            bool isTwoPair = (pointCount[0] == 2 && pointCount[1] == 2);
            // 判斷是否為一對
            bool isOnePair = (pointCount[0] == 2 && pointCount[1] == 1);

            string tag = " ";
            if (isRoyalisFlush)
            {
                result = $"{colorList[0]}同花大順";
                tag = "皇家同花順";

            }
            else if (isStraightFlush)
            {
                result = $"{colorList[0]} 同花順";
                tag = "同花順";
            }
            else if (isStraight)
            {
                result = "順子";
                tag = "順子";
            }
            else if (isFourOfAKind)
            {
                result = $"{pointList[0]} 鐵支";
                tag = "四條";
            }
            else if (isFullHouse)
            {
                result = $"{pointList[0]}三張{pointList[1]}兩張 葫蘆";
                tag = "葫蘆";
            }
            else if (isFlush)
            {
                result = $"{colorList[0]} 同花";
                tag = "同花";
            }
            else if (isThreeOfAKind)
            {
                result = $"{pointList[0]} 三條";
                tag = "三條";
            }
            else if (isTwoPair)
            {
                result = $"{pointList[0]},{pointList[1]} 兩對";
                tag = "兩對";
            }
            else if (isOnePair)
            {
                result = $"{pointList[0]} 一對";
                tag = "一對";
            }
            else
            {
                result = "雜牌";
            }

            lblResult.Text = result;
            return (tag, result);
        }

        private async void btnCheck_Click(object sender, EventArgs e)
        {
            var chk = CheckPoker();// 判斷牌型
            string tag = chk.Item1;
            string result = chk.Item2;

            // 根據牌型賠率計算中獎金額
            var betOdds = new Dictionary<string, double>
            {
                { "皇家同花順", 250 },
                { "同花順", 50 },
                { "四條", 25 },
                { "葫蘆", 9 },
                { "同花", 6 },
                { "順子", 4 },
                { "三條", 3 },
                { "兩對", 2 },
                { "一對", 1 },
                { " ", 0 }
            };

            double odds = betOdds[tag];
            double betAmount = 0;
            //總資金
            string txtAmt = lblAmt.Text.Replace("NT$", "").Replace(",", "").Trim();
            double totalAmt = 0;
            if (double.TryParse(txtAmt, out totalAmt))
            {

                string txtDetAmt = txtDet.Text.Replace("NT$", "").Replace(",", "").Trim();
                double detAmt = Convert.ToDouble(txtDetAmt);
                betAmount = totalAmt + detAmt * odds;

                if (odds > 0)
                {
                    msgLabel.Text = $"你中了 {result}，賠率 {odds} 倍，獎金 {detAmt * odds:C0}";
                    betAmount += detAmt;
                    msgLabel.Visible = true;
                }
                this.lblAmt.Text = string.Format("{0:C0}", betAmount);

                await Task.Delay(2000);// 暫停2000ms

                msgLabel.Text = "";
                msgLabel.Visible = false;

                this.txtDet.Tag = "NT$";
                this.txtDet.Text = string.Format("{0:C0}", 0);

                lblResult.Text = "";
                btnChangeCard.Enabled = false;
                btnCheck.Enabled = false;
                btnDealCard.Enabled = false;
                txtDet.Enabled = true;
                btnDet.Enabled = true;

                if (betAmount <= 0)
                {
                    // 總資金不足，遊戲結束或重置遊戲
                    DialogResult rs = MessageBox.Show("總資金不足是否重置遊戲", "關閉視窗", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (rs == DialogResult.Yes)
                    {
                        reset();
                    }
                    else
                    {
                        // 關閉遊戲
                        this.Close();
                    }

                }
            } 
            else
            {
                msgLabel.Text = "總資金金額無效";
                msgLabel.Visible = true;
            }

        }

        private void frmPoker_Load(object sender, EventArgs e)
        {
            this.txtDet.Tag = "NT$";
            this.txtDet.Text = string.Format("{0:C0}", 0);

            this.lblAmt.Text = string.Format("{0:C0}", 1000000);

            // 需要格式化的 TextBox 加入事件處理
            this.txtDet.KeyPress += new KeyPressEventHandler(Integer_KeyPress);
            this.txtDet.TextChanged += new EventHandler(TextBox_TextChanged);
            this.txtDet.Validating += new CancelEventHandler(TextBox_Validating);
            this.txtDet.Leave += new EventHandler(TextBox_Leave);

        }
        private void Integer_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string currentText = textBox.Text;
            msgLabel.Text = "";
            msgLabel.Visible = false;
            if ( (btnDealCard.Enabled == false) && (e.KeyChar == 113 || e.KeyChar == 119 || e.KeyChar == 101 || e.KeyChar == 114 || e.KeyChar == 116 || e.KeyChar == 121 || e.KeyChar == 97 || e.KeyChar == 115 || e.KeyChar == 100))
            {
                msgLabel.Visible = true;
                msgLabel.Text = "你按了秘技按鍵: " + e.KeyChar + " 測試牌型";
                e.Handled = true;  // 阻止輸入非數字
            }
            // 只允許數字、小數點和控制鍵（倒退鍵等）
            else if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
            {

                msgLabel.Text = "只能輸入數字";
                msgLabel.Visible = true;
                e.Handled = true;  // 阻止輸入非數字
            }

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string currentText = textBox.Text;
            string controlName = textBox.Name;

            // 根據 Tag 移除對應符號和逗號取得純數值
            string dataValue = currentText.Replace("NT$", "").Replace("%", "").Replace(",", "").Trim();

            // 如果為空或只是小數點，不進行格式化
            if (string.IsNullOrEmpty(dataValue) || dataValue == ".")
            {
                if (controlName == "txtDet")
                {
                    textBox.Text = "0";
                }

                //return;
            }

            // 如果以小數點結尾或者小數點後的最後一位為0時，不進行格式化
            if (dataValue.EndsWith("."))
                return;

            // 將字串轉換為數值
            if (double.TryParse(dataValue, out double value))
            {

                string formattedText = "";

                //判斷是否有小數部分: 有小數依小數位數顯示
                int decimalIndex = 0;  // 小數位數
                int idx = dataValue.IndexOf(".");

                if (idx == -1)
                    decimalIndex = 0;  // 沒有小數
                else
                {
                    decimalIndex = dataValue.Substring(idx + 1).Length;  // 小數位數
                }


                if (controlName == "txtDet")
                {
                    //總資金
                    string txtAmt = lblAmt.Text.Replace("NT$", "").Replace(",", "").Trim();
                    double totalAmt = Convert.ToDouble(txtAmt);
                    if (totalAmt <= 0)
                    {
                        msgLabel.Text = "總資金: " + lblAmt.Text;
                        msgLabel.Visible = true;
                        btnDet.Enabled = false;
                    }
                    else if (value < 0 )
                    {
                        msgLabel.Text = "下注金額不得小於 0";
                        msgLabel.Visible = true;
                        btnDet.Enabled = false;
                    }
                    else if (value > totalAmt)
                    {
                        msgLabel.Text = "下注金額不能大於總資金";
                        msgLabel.Visible = true;
                        btnDet.Enabled = false;
                    }
                    else
                    {
                        msgLabel.Text = "";
                        msgLabel.Visible = false;
                        btnDet.Enabled = true;                        
                    }

                    formattedText = string.Format("{0:C" + decimalIndex.ToString() + "}", value);                    
                }
                

                textBox.Text = formattedText;
                // 游標移到末尾
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox_Validating(sender, e, false);
        }

        private void TextBox_Validating(object sender, CancelEventArgs e, bool chk)
        {

            double value = 0;
            TextBox textBox = (TextBox)sender;
            string currentText = textBox.Text;
            string controlName = textBox.Name;
            string formattedText = "";
            string formattedString = "";

            // 根據 Tag 移除對應符號和逗號取得純數值
            string dataValue = currentText.Replace("NT$", "").Replace("%", "").Replace(",", "").Trim();
            if (chk)
            {
                if (dataValue.Contains(".") && dataValue.EndsWith("0"))
                {
                    dataValue = dataValue.TrimEnd('0');//如果是離開事件，去掉末尾的0
                }
            }

            if (double.TryParse(dataValue, out value))
            {
                //判斷是否有小數部分: 有小數依小數位數顯示
                int decimalIndex = 0;  // 小數位數
                int idx = dataValue.IndexOf(".");

                if (idx == -1)
                    decimalIndex = 0;  // 沒有小數
                else
                {
                    decimalIndex = dataValue.Substring(idx + 1).Length;  // 小數位數
                }

                if (controlName == "txtDet")
                {
                    //總資金
                    string txtAmt = lblAmt.Text.Replace("NT$", "").Replace(",", "").Trim();
                    double totalAmt = Convert.ToDouble(txtAmt);
                    if (totalAmt <= 0)
                    {
                        msgLabel.Text = "總資金: " + lblAmt.Text;

                        msgLabel.Visible = true;
                        btnDet.Enabled = false;
                        e.Cancel = true;// 阻止焦點離開
                    }
                    else if (value < 0)
                    {
                        msgLabel.Text = "下注金額不得小於 0";
                        msgLabel.Visible = true;
                        btnDet.Enabled = false;
                        e.Cancel = true;// 阻止焦點離開
                    }
                    else if (value > totalAmt)
                    {
                        msgLabel.Text = "下注金額不能大於總資金";

                        msgLabel.Visible = true;
                        btnDet.Enabled = false;
                        e.Cancel = true;// 阻止焦點離開
                    }
                    else
                    {
                        msgLabel.Text = "";
                        btnDet.Enabled = true;
                        msgLabel.Visible = false;
                    }

                    formattedString = "{0:C" + decimalIndex.ToString() + "}";
                    formattedText = string.Format(formattedString, value);
                }

                textBox.Text = formattedText;
                // 游標移到末尾
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox_Validating(sender, new CancelEventArgs(), true);
        }

        private void reset()
        {
            this.txtDet.Tag = "NT$";
            this.txtDet.Text = string.Format("{0:C0}", 0);
            this.lblAmt.Text = string.Format("{0:C0}", 1000000);
            msgLabel.Text = "";
            msgLabel.Visible = false;
            for (int i = 0; i < 5; i++)
            {
                pic[i].MouseClick -= new MouseEventHandler(pic_Click);
                pic[i].Image = GetImage("back");
                pic[i].Name = "pic" + i;
                pic[i].Enabled = false;//發牌之前，關閉pic[i]的事件，以免誤按
                pic[i].Tag = "back";//記錄初始狀態為牌背
                
                pic[i].MouseClick += new MouseEventHandler(pic_Click);
            }

        }
        private void frmPoker_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("是否要離開？", "關閉視窗", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                reset();
                e.Cancel = false;
            }
        }

        private void btnDet_Click(object sender, EventArgs e)
        {

            //btnDealCard.Enabled = true;
            txtDet.Enabled = false;
            btnDet.Enabled = false;
            //總資金
            string txtAmt = lblAmt.Text.Replace("NT$", "").Replace(",", "").Trim();
            double totalAmt = Convert.ToDouble(txtAmt);

            string txtDetAmt = txtDet.Text.Replace("NT$", "").Replace(",", "").Trim();
            double detAmt = Convert.ToDouble(txtDetAmt);

            this.lblAmt.Text = string.Format("{0:C0}", totalAmt - detAmt);

            //當按押注鈕時，會先判斷btnCheck是否啟用，如果btnCheck已經啟用，表示已經發牌(先按了秘技按鍵)
            if (btnCheck.Enabled)
            {
                btnDealCard.Enabled = false;//如果已經發牌了，就不允許再按發牌鈕了，直接判斷牌型
            }
            else
            {
                //還沒有發牌，啟用發牌鈕及蓋牌
                btnDealCard.Enabled = true;
                for (int i = 0; i < 5; i++)
                {
                    pic[i].MouseClick -= new MouseEventHandler(pic_Click);
                    pic[i].Image = GetImage("back");
                    pic[i].Name = "pic" + i;
                    pic[i].Enabled = false;//發牌之前，關閉pic[i]的事件，以免誤按
                    pic[i].Tag = "back";//記錄初始狀態為牌背
                    pic[i].MouseClick += new MouseEventHandler(pic_Click);
                }

            }



        }
    }
}
