using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myappdll
{
    public partial class Form_点检样件_ : Sunny25.UIForm
    {
        private const int 点检数据上限 = 100000;
        private string 已保存文本 = string.Empty;

        public Form_点检样件_()
        {
            InitializeComponent();
        }

        private void Form_点检样件__Load(object sender, EventArgs e)
        {
            显示点检数据();
        }

        private void 显示点检数据()
        {
            this.uiTextBox1.Text = string.Join("\r\n", 点检样件.Config.点检数据 ?? new string[0]);
            已保存文本 = this.uiTextBox1.Text;
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            点检样件.Config.点检数据 = 取最近点检数据(this.uiTextBox1.Text);
            点检样件.Cfg(0);
            显示点检数据();
            Sunny25.Messagebox.Show("OK");
        }

        private static string[] 取最近点检数据(string text)
        {
            HashSet<string> seen = new HashSet<string>(StringComparer.Ordinal);
            string[] data = 读取条码行(text).Where(value => seen.Add(value)).ToArray();
            return data.Length > 点检数据上限
                ? data.Skip(data.Length - 点检数据上限).ToArray() : data;
        }

        private static IEnumerable<string> 读取条码行(string text)
        {
            return text.Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.None)
                .Select(清理条码).Where(value => value.Length > 0);
        }

        private static string 清理条码(string text)
        {
            StringBuilder result = new StringBuilder(text.Length);
            foreach (char value in text)
            {
                // 清除空白、控制字符及零宽字符/BOM 等不可见格式字符，保留有效符号和大小写。
                if (!char.IsWhiteSpace(value) && !char.IsControl(value) &&
                    char.GetUnicodeCategory(value) != UnicodeCategory.Format)
                {
                    result.Append(value);
                }
            }
            return result.ToString();
        }

        private void uiButton_添加_Click(object sender, EventArgs e)
        {
            using (Sunny25.UIInputForm form = new Sunny25.UIInputForm())
            {
                form.Text = "添加点检数据";
                form.Label.Text = "请输入点检数据：";
                form.CheckInputEmpty = true;
                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                string value = 清理条码(form.Editor.Text);
                if (string.IsNullOrEmpty(value))
                {
                    Sunny25.Messagebox.Show("点检数据不能为空");
                    return;
                }

                string text = this.uiTextBox1.Text;
                if (读取条码行(text).Contains(value, StringComparer.Ordinal))
                {
                    Sunny25.Messagebox.Show("该条码已存在，不能重复添加");
                    return;
                }

                string separator = text.Length > 0 && !text.EndsWith("\n") && !text.EndsWith("\r")
                    ? "\r\n" : string.Empty;
                this.uiTextBox1.Text = string.Join("\r\n", 取最近点检数据(text + separator + value));
                int start = this.uiTextBox1.TextLength - value.Length;
                this.uiTextBox1.Select(start, value.Length);
                this.uiTextBox1.ScrollToCaret();
            }
        }

        private void uiButton_删除_Click(object sender, EventArgs e)
        {
            if (this.uiTextBox1.TextLength == 0)
            {
                Sunny25.Messagebox.Show("没有可删除的点检数据");
                return;
            }

            int start = this.uiTextBox1.SelectionStart;
            int end = start + Math.Max(this.uiTextBox1.SelectionLength - 1, 0);
            int firstLine = this.uiTextBox1.GetLineFromCharIndex(start);
            int lastLine = this.uiTextBox1.GetLineFromCharIndex(end);
            List<string> lines = this.uiTextBox1.Lines.ToList();
            int count = lastLine - firstLine + 1;
            if (Sunny25.Messagebox.Show($"是否删除选中的 {count} 行点检数据？", "",
                Sunny25.MessageboxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            lines.RemoveRange(firstLine, count);
            this.uiTextBox1.Text = string.Join("\r\n", lines);
            int nextStart = lines.Count == 0 ? 0 : this.uiTextBox1.GetFirstCharIndexFromLine(
                Math.Min(firstLine, lines.Count - 1));
            this.uiTextBox1.Select(Math.Max(nextStart, 0), 0);
            this.uiTextBox1.ScrollToCaret();
        }

        private void uiButton_刷新_Click(object sender, EventArgs e)
        {
            if (this.uiTextBox1.Text != 已保存文本 &&
                Sunny25.Messagebox.Show("当前修改尚未保存，是否放弃修改并刷新？", "",
                    Sunny25.MessageboxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            点检样件.Cfg(1);
            显示点检数据();
        }
    }
}
