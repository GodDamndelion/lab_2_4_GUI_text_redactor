//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace WindowsFormsApp1
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }
//    }
//}

using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string fileName, saveFileName;
        public Form1()
        {
            InitializeComponent();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() ==
            System.Windows.Forms.DialogResult.OK)
            {
                StreamReader f_In = new StreamReader(openFileDialog1.FileName);
                fileName = openFileDialog1.FileName;
                textBoxFile1.Text = f_In.ReadToEnd();
                textBoxFile2.Clear();
                f_In.Close();
            }
        }
        private void option1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s1, s2;
            textBoxFile2.Clear();
            for (int i = 0; i < textBoxFile1.Lines.Count(); i++)
            {
                s1 = textBoxFile1.Lines[i];
                string[] s_mas = s1.Split(' ', ',', '.');
                int countWord = 0;
                foreach (string str in s_mas)
                    if (str != "") countWord++;
                s2 = String.Concat(/*i.ToString(), " ; ", s1, " ; ", */countWord);
                if (textBoxFile2.Text.Length > 0)
                {
                    textBoxFile2.AppendText(Environment.NewLine);
                }
                textBoxFile2.AppendText(s2);
            }
        }
        private void option2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s1, s2;
            textBoxFile2.Clear();
            for (int i = 0; i < textBoxFile1.Lines.Count(); i++)
            {
                s1 = textBoxFile1.Lines[i];
                int countWord = 0;
                int j = 1;
                if (s1 != "" && s1[0] != ' ' && s1[0] != '.' && s1[0] != ',') countWord++;
                while (j < s1.Length)
                {
                    if (s1[j] != ' ' && s1[j] != '.' && s1[j] != ',' && (s1[j - 1] == ' ' || s1[j - 1] == '.' || s1[j - 1] == ','))
                        countWord++;
                    j++;
                }
                s2 = /*i.ToString() + " ; " + s1 + " ; " + */countWord.ToString();
                if (textBoxFile2.Text.Length > 0)
                {
                    textBoxFile2.AppendText(Environment.NewLine);
                }
                textBoxFile2.AppendText(s2);
            }
        }
        //private void option3ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (textBoxFile1.TextLength != 0)
        //    {
        //        int count;
        //        byte[] byteArray;
        //        char[] charArray;
        //        UnicodeEncoding uniEncoding = new UnicodeEncoding();
        //        byte[] secondString =
        //        uniEncoding.GetBytes(Path.GetInvalidPathChars());
        //        using (MemoryStream memStream =
        //        new MemoryStream(textBoxFile1.TextLength *
        //        UnicodeEncoding.CharSize))
        //        {
        //            memStream.Write(uniEncoding.GetBytes(textBoxFile1.Text),
        //            0, textBoxFile1.TextLength * UnicodeEncoding.CharSize);
        //            textBoxFile2.Clear();
        //            memStream.Seek(0, SeekOrigin.Begin);
        //            StreamReader memrdr = new StreamReader(memStream,
        //            Encoding.Unicode);
        //            int c1 = -1, c2 = memrdr.Read();
        //            int i = 0;
        //            while (c2 != -1)
        //            {
        //                int countWord = 0;
        //                // CR LF: возврат каретки + перевод строки,
        //                // символы Юникода 000D + 000A
        //                textBoxFile2.AppendText((i++).ToString() + " ; ");
        //                while (c2 != '\r' && c2 != -1)
        //                {
        //                    c1 = c2;
        //                    c2 = memrdr.Read();
        //                    textBoxFile2.AppendText(((char)c1).ToString());
        //                    if ((c2 == '\r' || c2 == -1 || c2 == ' ' ||
        //                    c2 == '.' || c2 == ',') && (c1 != ' ' &&
        //                    c1 != '.' && c1 != ',' && c1 != -1))
        //                        countWord++;
        //                }
        //                if (c2 == '\r')
        //            {
        //                    c2 = memrdr.Read();
        //                    c1 = c2;
        //                    c2 = memrdr.Read();
        //                }
        //                textBoxFile2.AppendText(" ; " + countWord + "\n");
        //            }
        //            if (c1 == '\n' && c2 == -1)
        //                textBoxFile2.AppendText((++i).ToString() + " ; ; 0");
        //        }
        //    }
        //}
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Первые две опции считают количество слов в строке.\n" +
            "Последняя преобразует теги из данбуры в теги из Артдука.");

            //"4. Дан текстовый файл, содержащий слова, разделенные одним или\n" +
            //"несколькими пробелами. Создать файл целых чисел, в котором каждой\n" +
            //"строке исходного файла соответствует в выходном файле число, равное\n" +
            //"количеству слов в ней. Пустой строке или строке, состоящей из одних\n" +
            //"пробелов, соответствует число ноль.");

            //"Дан текстовый файл. Слова разделяются пробелами,\n" +
            //"запятыми, точками. Переписать его содержимое\n" +
            //"в другой файл, каждая строка которого имеет\n" +
            //"следующую структуру: номер строки; строка;\n" +
            //"количество слов в строке.", "Условие задачи"); //Чтобы с @ строка не упиралась влево (некрасиво)
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName == null)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                StreamWriter f_Out = new StreamWriter(fileName);
                f_Out.WriteLine(textBoxFile1.Text);
                f_Out.Close();
            }

            if (saveFileName == null)
            {
                saveResultAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                StreamWriter f_Out = new StreamWriter(saveFileName);
                f_Out.WriteLine(textBoxFile2.Text);
                f_Out.Close();
            }
            // для самостоятельной работы
            // (сохранение текста в файл)
            // (сохранение результата в файл)
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Сохранение исходных данных (левый столбец)";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter f_Out = new StreamWriter(saveFileDialog1.FileName);
                fileName = saveFileDialog1.FileName;
                f_Out.WriteLine(textBoxFile1.Text);
                f_Out.Close();
            }
            // для самостоятельной работы
            // (сохранение текста в файл)
        }
        private void saveResultAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Сохранение результата (правый столбец)";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter f_Out = new StreamWriter(saveFileDialog1.FileName);
                saveFileName = saveFileDialog1.FileName;
                f_Out.WriteLine(textBoxFile2.Text);
                f_Out.Close();
            }
            // для самостоятельной работы
            // (сохранение результата в файл)
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // До закрытия формы
        {
            Form2 question = new Form2();
            question.Owner = this;
            question.ShowDialog();
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 question = new Form2();
            question.Owner = this;
            question.Show();
            // для самостоятельной работы
            // (сохранение несохраненных данных)
            // (очистка текстовых полей)
        }
        //      {"", "" },
        //      {"", "#@artdyk" },
        //      {"#@artdyk", "#@artdyk"},
        //      #@artdyk
        //      "#@artdyk"
        Dictionary<string, string> dictionary = new Dictionary<string, string>()
        {
            //Copyrights
            {"#SeishunButaYarou@artdyk",    "#ЭтотГлупыйСвинНеПонимаетМечтуДевочкиЗайки@artdyk" },
            {"#SteinsGate@artdyk",          "#ВратаШтейна@artdyk" },
            {"#SpiceAndWolf@artdyk",        "#ВолчицаИПряности@artdyk" },
            {"#BocchiTheRock@artdyk",       "#ОдинокийРокер@artdyk" },
            {"#Clannad@artdyk",             "#Кланнад@artdyk" },
            {"#KonoSubarashiiSekaiNiShukufukuWo@artdyk",                    "#Коносуба@artdyk" },
            {"#KaguyaSamaWaKokurasetaiTensaiTachiNoRenaiZunousen@artdyk",   "#ГоспожаКагуя@artdyk" },
            {"#ReZeroKaraHajimeruIsekaiSeikatsu@artdyk",                    "#ReZero@artdyk" },
            {"#YahariOreNoSeishunLovecomeWaMachigatteiru@artdyk",           "#Oregairu@artdyk #МояШкольнаяРомантическаяЖизньНеУдалась@artdyk" },
            {"#NeonGenesisEvangelion@artdyk",                               "#Evangelion@artdyk #Евангелион@artdyk #ЕвангелионНовогоПоколения@artdyk" },

            //Characters
            {"#SakurajimaMai@artdyk",       "#МайСакурадзима@artdyk" },
            {"#Aqua@artdyk",                "#Аква@artdyk" },
            {"#Darkness@artdyk",            "#Даркнесс@artdyk" },
            {"#Megumin@artdyk",             "#Мегумин@artdyk" },
            {"#SatouKazuma@artdyk",         "#КазумаСато@artdyk" },
            {"#HayasakaAi@artdyk",          "#АйХаясака@artdyk" },
            {"#Rem@artdyk",                 "#Рем@artdyk" },
            {"#Ram@artdyk",                 "#Рам@artdyk" },
            {"#PetraLeyte@artdyk",          "#ПетраЛейте@artdyk #ПетраЛейтэ@artdyk" },
            {"#FredericaBaumann@artdyk",    "#ФредерикаБауманн@artdyk" },
            {"#GawrGura@artdyk",            "#ГаврГура@artdyk" },
            {"#HiratsukaShizuka@artdyk",    "#ШизукаХирацука@artdyk" },
            {"#KatsuragiMisato@artdyk",     "#МисатоКацураги@artdyk" },
            {"#OkabeRintarou@artdyk",       "#РинтароОкабэ@artdyk" },
            {"#MakiseKurisu@artdyk",        "#КурисуМакисэ@artdyk" },
            {"#HiyajouMaho@artdyk",         "#МахоХиядзё@artdyk" },
            {"#Holo@artdyk",                "#Холо@artdyk" },
            {"#CraftLawrence@artdyk",       "#КрафтЛоуренс@artdyk" },
            {"#GotouHitori@artdyk",         "#ХиториГото@artdyk" },
            {"#FurukawaNagisa@artdyk",      "#НагисаФурукава@artdyk" },
            {"#IbukiFuuko@artdyk",          "#ФукоИбуки@artdyk" },
            {"#SakagamiTomoyo@artdyk",      "#ТомоэСакагами@artdyk #ТомоёСакагами@artdyk #ТомойоСакагами@artdyk" },
            {"#OkazakiTomoya@artdyk",       "#ТомояОказаки@artdyk" },
            {"#OkazakiUshio@artdyk",        "#УсиоОказаки@artdyk" },

            //General
            {"#Ass@artdyk",                 "#Жопа@artdyk #Жопка@artdyk #Попа@artdyk #Попка@artdyk #Задница@artdyk" },
            {"#Navel@artdyk",               "#Пупок@artdyk #Живот@artdyk #Животик@artdyk" },
            {"#Breasts@artdyk",             "#Грудь@artdyk" },
            {"#DoubleV@artdyk",             "#DoubleVSign@artdyk #DoublePeace@artdyk #ДвойнойPeace@artdyk #ДвойнойМир@artdyk #ДвойнойПис@artdyk" },
            {"#Smug@artdyk",                "#СамодовольноеХе@artdyk #Ухмылка@artdyk" },
            {"#Back@artdyk",                "#Спина@artdyk" },
            {"#Smile@artdyk",               "#Улыбка@artdyk #Улыбается@artdyk #хе@artdyk" },
            {"#OneEyeClosed@artdyk",        "#ОдинГлазЗакрыт@artdyk" }, //Без #Wink@artdyk и #Подмигивает@artdyk!!!
            {"#ClosedEyes@artdyk",          "#ЗакрытыеГлаза@artdyk #ГлазаЗакрыты@artdyk"},
            {"#TongueOut@artdyk",           "#ПоказываетЯзык@artdyk" },
            {"#Tongue@artdyk",              "#Язык@artdyk" },
            {"#OpenMouth@artdyk",           "#ОткрытыйРот@artdyk #РотОткрыт@artdyk" },
            {"#ClosedMouth@artdyk",         "#ЗакрытыйРот@artdyk #РотЗакрыт@artdyk" },
            {"#Birthday@artdyk",            "#ДеньРождения@artdyk" },
            {"#Maid@artdyk",                "#Горничная@artdyk #ФормаГорничной@artdyk #КостюмГорничной@artdyk" },
            {"#Smoking@artdyk",             "#Курит@artdyk" },
            {"#Cigarette@artdyk",           "#Сигарета@artdyk #Сигареты@artdyk" },
            {"#PartedLips@artdyk",          "#ПриоткрытыеГубы@artdyk #ПриоткрытыйРот@artdyk" },
            {"#Labcoat@artdyk",             "#ЛабораторныйХалат@artdyk" },
            {"#Shirt@artdyk",               "#Рубашка@artdyk" },
            {"#Necktie@artdyk",             "#Галстук@artdyk" },
            {"#Crossover@artdyk",           "#Кроссовер@artdyk" },
            {"#SchoolUniform@artdyk",       "#ШкольнаяФорма@artdyk" },
            {"#Food@artdyk",                "#Еда@artdyk" },
            {"#TransparentBackground@artdyk",   "#ПрозрачныйФон@artdyk (в оригинале)" },

            //Meta
            {"#Highres@artdyk",             "#HighResolution@artdyk #Качественный@artdyk" },
            {"#Absurdres@artdyk",           "#AbsurdResolution@artdyk #ОченьКачественный@artdyk" },
            {"#AlphaTransparency@artdyk",   "#АльфаПрозрачность@artdyk (в оригинале)" },
            {"#OfficialArt@artdyk",         "#ОфициальныйАрт@artdyk #Официальный@artdyk" },
        };
        Dictionary<string, string> replace_list = new Dictionary<string, string>()
        {
            {"#V@artdyk",                   "#VSign@artdyk #PeaceSign@artdyk #Peace@artdyk #Мир@artdyk #Пис@artdyk" },
            {"#...@artdyk",                 "#эм@artdyk" },
            {"#><@artdyk",                  "#TightlyClosedEyes@artdyk #КрепкоЗакрытыеГлаза@artdyk" },
            {"#Xd@artdyk",                  "#XD@artdyk" },
            {"#3@artdyk",                   "#CatFace@artdyk" }, //:3 ;3 #X3@artdyk уже содержит 2 нужных тега и в переводе не нуждается
            {"#YahariOreNoSeishunLovecomeWaMachigatteiru.@artdyk", "#YahariOreNoSeishunLovecomeWaMachigatteiru@artdyk" },
        };
        string[] black_list =
        {
            "#CommentaryRequest@artdyk",
            "#Commentary@artdyk",
            "#EnglishCommentary@artdyk",
            "#PaidRewardAvailable@artdyk",
            "#HaysacaA.Smithee@artdyk",
            "#p@artdyk", "#P@artdyk", //:p ;p
            "#d@artdyk", "#D@artdyk", //:d ;d
            "#q@artdyk", "#Q@artdyk", //:q ;q
            "#o@artdyk", "#O@artdyk", //:o ;o
            "#Translated@artdyk",
            "#TranslationRequest@artdyk",
            "#PartiallyTranslated@artdyk",
            "#CheckTranslation@artdyk",
            "#SymbolOnlyCommentary@artdyk",
            "#PortugueseCommentary@artdyk",
            "#PartialCommentary@artdyk",
            "#BadId@artdyk",
            "#BadPixivId@artdyk",
            "#BadTwitterId@artdyk",
            "#DangoDaikazoku@artdyk",
        };
        private void tagConversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s1, s2;
            bool was_meta = false;
            bool was_deleted;
            textBoxFile2.Clear();
            for (int i = 0; i < textBoxFile1.Lines.Count(); ++i)
            {
                was_deleted = false;
                s1 = textBoxFile1.Lines[i];
                string[] s_mas = s1.Split(' ', '!', '-', '~', ':', ';');
                //int countWord = 0;
                //foreach (string str in s_mas)
                //    if (str != "") countWord++;
                //s2 = String.Concat(/*i.ToString(), " ; ", s1, " ; ", */countWord);

                s2 = "";
                if (s_mas.Length == 1)
                {
                    if (i != 0)
                        s2 += "\r\n";
                }
                else
                {
                    s_mas[0] = "#";
                    s_mas[s_mas.Length - 1] = "@artdyk";
                    for (int j = 1; j < s_mas.Length - 1; ++j)
                    {
                        if (s_mas[j] != "" && (s_mas[j].Contains('(') || s_mas[j].Contains(')')))
                            s_mas[j] = "";
                        if (s_mas[j] != "")
                            s_mas[j] = s_mas[j][0].ToString().ToUpper() + s_mas[j].Remove(0, 1); //Замена маленьких букв на большие
                        //s_mas[j][0] = s_mas[j][0].ToString().ToUpper(); // Нельзя, т.к. у строк отдельные символы только для чтения...
                    }

                }
                s2 += String.Concat(s_mas);
                if (String.Concat(s_mas) == "Meta")
                {
                    s2 += "\r\n#Art@artdyk #Арт@artdyk";
                    if (AddBirthdayTagsCheckBox.Checked)
                        s2 += "\r\n#BirthdayTD@artdyk #TD@artdyk #ДеньРожденияТД@artdyk #ТД@artdyk";
                    was_meta = true;
                }
                if (black_list.Contains(s2))
                {
                    was_deleted = true;
                }
                if (replace_list.ContainsKey(s2))
                {
                    s2 = replace_list[s2];
                }
                if (dictionary.ContainsKey(s2))
                {
                    s2 += " " + dictionary[s2];
                }
                //s2 += String.Join(" ", s_mas);
                if (!was_deleted)
                {
                    if (textBoxFile2.Text.Length > 0)
                    {
                        textBoxFile2.AppendText(Environment.NewLine);
                    }
                    textBoxFile2.AppendText(s2);
                }
            }
            if (!was_meta)
            {
                textBoxFile2.AppendText(Environment.NewLine + "\r\nMeta\r\n#Art@artdyk #Арт@artdyk");
                if (AddBirthdayTagsCheckBox.Checked)
                    textBoxFile2.AppendText(Environment.NewLine + "#BirthdayTD@artdyk #TD@artdyk #ДеньРожденияТД@artdyk #ТД@artdyk");
            }
        }
        private void tagConversionButton_Click(object sender, EventArgs e)
        {
            tagConversionToolStripMenuItem_Click(sender, e);
        }
        public void closingSaving(bool answer, object sender, EventArgs e)
        {
            if (answer)
            {
                saveToolStripMenuItem_Click(sender, e);
            }
            textBoxFile1.Clear();
            textBoxFile2.Clear();
            fileName = null;
            saveFileName = null;
        }
    }
}

