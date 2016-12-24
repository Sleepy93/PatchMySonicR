using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PatchMySonicR
{
    public partial class Form1 : Form
    {
        const string ExeName = "sonicr.exe";
        const string FixedName = "sonicr_patched.exe";
        const string ConfigName = "sonicr.inf";

        const uint UnlockPtr = 0x00070584;
        const uint UnlockLen = 0x23;

        const uint DrivePtr = 0x0011D2FC;
        const uint DriveLen = 0xC4;

        const uint ResPointer = 0x1C;
        const uint ResLen = 0x0C;

        static byte[] Original =
        {
            0x2E, 0xFF, 0x15, 0x8C, 0x05, 0x95, 0x00, 0x29, 0xF8, 0x83, 0xC3, 0x04,
            0x99, 0x31, 0xD0, 0x29, 0xD0, 0x01, 0xC6, 0x89, 0x44, 0x2B, 0xC0, 0x83,
            0xFB, 0x28, 0x74, 0x1B, 0x2E, 0xFF, 0x15, 0x8C, 0x05, 0x95, 0x00
        };
        static byte[] Cracked =
        {
            0xB8, 0x31, 0x00, 0x00, 0x00, 0x90, 0x90, 0x29, 0xF8, 0x83, 0xC3, 0x04,
            0x99, 0x31, 0xD0, 0x29, 0xD0, 0x01, 0xC6, 0x89, 0x44, 0x2B, 0xC0, 0x83,
            0xFB, 0x28, 0x74, 0x1B, 0xB8, 0x01, 0x00, 0x00, 0x00, 0x90, 0x90
        };

        byte[] DriveInfo =
        {
            0x64, 0x3A, 0x5C, 0x00, 0x63, 0x3A, 0x5C, 0x00, 0x63, 0x3A, 0x5C, 0x00,
            0x64, 0x3A, 0x5C, 0x00, 0x64, 0x3A, 0x5C, 0x00, 0x65, 0x3A, 0x5C, 0x00,
            0x65, 0x3A, 0x5C, 0x00, 0x66, 0x3A, 0x5C, 0x00, 0x66, 0x3A, 0x5C, 0x00,
            0x67, 0x3A, 0x5C, 0x00, 0x67, 0x3A, 0x5C, 0x00, 0x68, 0x3A, 0x5C, 0x00,
            0x68, 0x3A, 0x5C, 0x00, 0x69, 0x3A, 0x5C, 0x00, 0x69, 0x3A, 0x5C, 0x00,
            0x6A, 0x3A, 0x5C, 0x00, 0x6A, 0x3A, 0x5C, 0x00, 0x6B, 0x3A, 0x5C, 0x00,
            0x6B, 0x3A, 0x5C, 0x00, 0x6C, 0x3A, 0x5C, 0x00, 0x6C, 0x3A, 0x5C, 0x00,
            0x6D, 0x3A, 0x5C, 0x00, 0x6D, 0x3A, 0x5C, 0x00, 0x6E, 0x3A, 0x5C, 0x00,
            0x6E, 0x3A, 0x5C, 0x00, 0x6F, 0x3A, 0x5C, 0x00, 0x6F, 0x3A, 0x5C, 0x00,
            0x70, 0x3A, 0x5C, 0x00, 0x70, 0x3A, 0x5C, 0x00, 0x71, 0x3A, 0x5C, 0x00,
            0x71, 0x3A, 0x5C, 0x00, 0x72, 0x3A, 0x5C, 0x00, 0x72, 0x3A, 0x5C, 0x00,
            0x73, 0x3A, 0x5C, 0x00, 0x73, 0x3A, 0x5C, 0x00, 0x74, 0x3A, 0x5C, 0x00,
            0x74, 0x3A, 0x5C, 0x00, 0x75, 0x3A, 0x5C, 0x00, 0x75, 0x3A, 0x5C, 0x00,
            0x76, 0x3A, 0x5C, 0x00, 0x76, 0x3A, 0x5C, 0x00, 0x77, 0x3A, 0x5C, 0x00,
            0x77, 0x3A, 0x5C, 0x00, 0x78, 0x3A, 0x5C, 0x00, 0x78, 0x3A, 0x5C, 0x00,
            0x79, 0x3A, 0x5C, 0x00, 0x79, 0x3A, 0x5C, 0x00, 0x7A, 0x3A, 0x5C, 0x00,
            0x7A, 0x3A, 0x5C, 0x00
        };

        static char[] res_delim = { '*', 'x', 'X' };

        #region CommentBlock
        // Details of Crack
        #region Crack
        // UnlockThe Game
        // 00070584 - 000705A6 
        // original:    2EFF158C05950029F883C3049931D029D001C689442BC083FB28741B2EFF158C059500
        // fixed:       B831000000909029F883C3049931D029D001C689442BC083FB28741BB8010000009090

        //Fix Drive's Letter:
        //0011D2FC - 0011D3BF
        // original:    d:\.c:\.c:\.d:\.d:\.e:\.e:\.f:\.f:\.g:\.g:\.h:\.h:\.i:\.i:\.j:\.j:\.k:\.k:\.l:\.l:\.m:\.m:\.n:\.n:\.o:\.o:\.p:\.p:\.q:\.q:\.r:\.r:\.s:\.s:\.t:\.t:\.u:\.u:\.v:\.v:\.w:\.w:\.x:\.x:\.y:\.y:\.z:\.z:\
        // fixed:       h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\.h:\
        #endregion

        //Details of Resolution Fix
        #region ResolutionFix
        /*
        all data: len:0C
        00001C - 000028
        Width:  00001C - 00001D
        Height: 00001E - 00001F
        Width:  000020 - 000021
        Height: 000022 - 000023
        Width:  000024 - 000025
        Height: 000026 - 000027
        */

        #endregion
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_exepatch_Click(object sender, EventArgs e)
        {
            byte[] tmp = File.ReadAllBytes(ExeName);
            for (int i = 0; i < UnlockLen; i++)
                if (tmp[UnlockPtr + i] != Original[i])
                {
                    //Very nem egyezik
                    if (MessageBox.Show("Maybe patched, path anyway?", Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        break;
                    else
                        goto next;
                }
            for (int i = 0; i < UnlockLen; i++)
                tmp[UnlockPtr + i] = Cracked[i];
            next:
            //Check
            for (int i = 0; i < DriveLen; i++)
                if (tmp[DrivePtr + i] != DriveInfo[i])
                {
                    //Very nem egyezik
                    if (MessageBox.Show("Maybe patched, path anyway?", Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        break;
                    else
                        goto end;
                }
            if (cb_drive.Text.Length == 0) goto end;
            byte ltr = Encoding.ASCII.GetBytes(cb_drive.Text)[0];
            for (int i = 0; i < DriveLen; i += 4)
                tmp[DrivePtr + i] = ltr;
            end:
            File.WriteAllBytes(FixedName, tmp);
            MessageBox.Show("Completed.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_respatch_Click(object sender, EventArgs e)
        {
            byte[] tmp = File.ReadAllBytes(ConfigName);
            byte[] rep;
            if (cb_res.Text.Length == 0)
                rep = BitConverter.GetBytes((ushort)Screen.PrimaryScreen.Bounds.Width << 16 | (ushort)Screen.PrimaryScreen.Bounds.Height);
            else
            {
                string[] spl = cb_res.Text.Split(res_delim);
                ushort width, height;
                if (ushort.TryParse(spl[0], out width) && ushort.TryParse(spl[1], out height))
                    rep = BitConverter.GetBytes(width << 16 | height);
                else
                {
                    if (MessageBox.Show("Not valid resolution. Use native resolution?", Text,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        rep = BitConverter.GetBytes((ushort)Screen.PrimaryScreen.Bounds.Width << 16 | (ushort)Screen.PrimaryScreen.Bounds.Height);
                    else
                        return;
                }
            }
            for (int i = 0; i < 12; i++)
                tmp[ResPointer + i] = rep[i % 4];
            File.WriteAllBytes(ConfigName, tmp);
        }
    }
}
