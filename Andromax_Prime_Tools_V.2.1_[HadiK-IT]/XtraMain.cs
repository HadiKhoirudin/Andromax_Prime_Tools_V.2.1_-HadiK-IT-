using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Andromax
{

    public partial class XtraMain : DevExpress.XtraEditors.XtraForm
    {
        public static XtraMain DelegateFunction;
        public static Stopwatch Watch = new Stopwatch();
        public string Operation = "";
        public string USERDIR = "";
        public bool lanjut = false;
        public string bootimg = "";
        public string bootlogo = "";
        public string cache = "";
        public string data = "";
        public string system = "";
        public string folderdata = Application.StartupPath + "\\Data\\";
        public string foldersave = "";
        public string foldersavebootimg = "";
        public string foldersavebootlogo = "";
        public string foldersavecache = "";
        public string foldersavedata = "";
        public string foldersavesystem = "";
        public XtraMain()
        {
            Load += LoadUI;
            FormClosing += CloseUI;
            DelegateFunction = this;
            InitializeComponent();
            USERDIR = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                USERDIR = Directory.GetParent(USERDIR).ToString();
                Console.WriteLine("User Dir Folder : " + USERDIR);
            }
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            RichTextBox.Invoke(new Action(() =>
            {
                RichTextBox.SelectionStart = RichTextBox.Text.Length;
                RichTextBox.ScrollToCaret();
            }));
        }
        private void RichTextBox_Clear()
        {
            RichTextBox.Invoke(new Action(() => { RichTextBox.Clear(); }));
        }
        public void RichLogs(string msg, Color colour, bool isBold, bool NextLine = false)
        {
            RichTextBox.Invoke(new Action(() =>
            {
                RichTextBox.SelectionStart = RichTextBox.Text.Length;
                var selectionColor = RichTextBox.SelectionColor;
                RichTextBox.SelectionColor = colour;
                if (isBold)
                {
                    RichTextBox.SelectionFont = new Font(RichTextBox.Font, FontStyle.Bold);
                }
                else
                {
                    RichTextBox.SelectionFont = new Font(RichTextBox.Font, FontStyle.Regular);
                }
                RichTextBox.AppendText(msg);
                RichTextBox.SelectionColor = selectionColor;
                if (NextLine)
                {
                    if (RichTextBox.TextLength > 0)
                    {
                        RichTextBox.AppendText(Constants.vbCrLf);
                    }
                }
            }));
        }
        public void Elapsed(Stopwatch Watch)
        {
            var elapsed = Watch.Elapsed;
            RichLogs(" ", Color.Azure, false, false);
            RichLogs("_________________________________________________________", Color.Azure, false, true);
            RichLogs("  Andromax Prime Tools V2.1 ", Color.Azure, false, false);
            RichLogs("[" + DateTime.Now.ToString("ddd, dd MMM yyyy HH:mm:ss" + "]"), Color.Azure, false, true);
            var str = string.Format("{0:00m}: {1:00s}", elapsed.Minutes, elapsed.Seconds);
            RichLogs("  All Tasks Is Completed ", Color.Azure, false, false);
            RichLogs("   -   ", Color.Azure, false, false);
            RichLogs("Elapsed Time : " + str, Color.Azure, false, true);
        }
        private void Progress(long value)
        {
            ProgressBar1.Invoke(new Action(() => { ProgressBar1.EditValue = value; }));
            Consoles.Delay(0.1);
        }
        private void LoadUI(object sender, EventArgs e)
        {
            RichLogs("<++++++++++++++ Andromax Prime Tools V2.1 ++++++++++++++>", Color.White, true, true);
            RichLogs("► Software  " + Constants.vbTab + ": ", Color.White, true, false);
            RichLogs("After Sales Tool", Color.White, true, true);
            RichLogs("► License  " + Constants.vbTab + ": ", Color.White, true, false);
            RichLogs("Technicians", Color.White, true, true);
            RichLogs("  =======================================================", Color.White, true, true);
            RichLogs("► Hire Me " + Constants.vbTab + ": https://hadikhoirudin.github.io/", Color.White, true, true);
            RichLogs("  =======================================================", Color.White, true, true);
            RichLogs("", Color.White, true, true);

            // Tab Root
            labelControl_root.Invoke(new Action(() => { labelControl_root.Enabled = false; }));

            // Tab Recovery Tools
            labelControl_install_recovery.Enabled = false;
            labelControl_recovery_for_imei.Enabled = false;
            labelControl_reboot_recovery.Enabled = false;
            labelControl_reboot_system.Enabled = false;
            labelControl_backup_rom.Enabled = false;
            labelControl_restore_rom.Enabled = false;

            // Tab Boot IMG
            labelControl_fw_magisk44.Enabled = false;
            labelControl_fw_magisk60.Enabled = false;
            labelControl_fw19.Enabled = false;
            labelControl_fw46.Enabled = false;
            labelControl_fw51.Enabled = false;
            labelControl_fw51_M.Enabled = false;
            labelControl_fw54.Enabled = false;
            labelControl_fw55.Enabled = false;
            labelControl_fw57.Enabled = false;
            labelControl_fw57_S.Enabled = false;
            labelControl_fw99.Enabled = false;
            labelControl_android6.Enabled = false;

            // Tab Unlock
            labelControl_unlock_bypass_pin.Enabled = false;
            labelControl_pilih_standby_sim.Enabled = false;
            labelControl_unlock_volte.Enabled = false;

            // Tab Fix Bootloop
            labelControl_install_rom_miui_recovery.Enabled = false;

        }

        private void Enable_access()
        {
            // Tab Recovery Tools
            labelControl_install_recovery.Invoke(new Action(() => { labelControl_install_recovery.Enabled = true; ; }));
            labelControl_recovery_for_imei.Invoke(new Action(() => { labelControl_recovery_for_imei.Enabled = true; ; }));
            labelControl_reboot_recovery.Invoke(new Action(() => { labelControl_reboot_recovery.Enabled = true; ; }));
            labelControl_reboot_system.Invoke(new Action(() => { labelControl_reboot_system.Enabled = true; ; }));
            labelControl_backup_rom.Invoke(new Action(() => { labelControl_backup_rom.Enabled = true; ; }));
            labelControl_restore_rom.Invoke(new Action(() => { labelControl_restore_rom.Enabled = true; ; }));

            // Tab Boot IMG
            labelControl_fw_magisk44.Invoke(new Action(() => { labelControl_fw_magisk44.Enabled = true; }));
            labelControl_fw_magisk60.Invoke(new Action(() => { labelControl_fw_magisk60.Enabled = true; }));
            labelControl_fw19.Invoke(new Action(() => { labelControl_fw19.Enabled = true; }));
            labelControl_fw46.Invoke(new Action(() => { labelControl_fw46.Enabled = true; }));
            labelControl_fw51.Invoke(new Action(() => { labelControl_fw51.Enabled = true; }));
            labelControl_fw51_M.Invoke(new Action(() => { labelControl_fw51_M.Enabled = true; }));
            labelControl_fw54.Invoke(new Action(() => { labelControl_fw54.Enabled = true; }));
            labelControl_fw55.Invoke(new Action(() => { labelControl_fw55.Enabled = true; }));
            labelControl_fw57.Invoke(new Action(() => { labelControl_fw57.Enabled = true; }));
            labelControl_fw57_S.Invoke(new Action(() => { labelControl_fw57_S.Enabled = true; }));
            labelControl_fw99.Invoke(new Action(() => { labelControl_fw99.Enabled = true; }));
            labelControl_android6.Invoke(new Action(() => { labelControl_android6.Enabled = true; }));

            // Tab Unlock
            labelControl_unlock_bypass_pin.Invoke(new Action(() => { labelControl_unlock_bypass_pin.Enabled = true; }));
            labelControl_pilih_standby_sim.Invoke(new Action(() => { labelControl_pilih_standby_sim.Enabled = true; }));
            labelControl_unlock_volte.Invoke(new Action(() => { labelControl_unlock_volte.Enabled = true; }));

            // Tab Fix Bootloop
            labelControl_install_rom_miui_recovery.Invoke(new Action(() => { labelControl_install_rom_miui_recovery.Enabled = true; }));
        }
        private void CloseUI(object sender, EventArgs e)
        {
            if (WorkerADB.IsBusy)
            {
                WorkerADB.Dispose();
                WorkerADB.CancelAsync();
            }
        }
        private string Data(string file)
        {
            return "\"" + folderdata + file + "\"";
        }
        private void ToDo(object sender, EventArgs e)
        {
            if (!WorkerADB.IsBusy)
                {
                Watch.Start();
                Watch.Restart();
                LabelControl label = (LabelControl)sender;
                Operation = label.Text;
                RichTextBox_Clear();
                RichLogs("Operation:", Color.Azure, true, false);
                RichLogs(Operation, Color.Lime, true, true);

                if (Operation.Contains("RESTORE ROM"))
                {
                    lanjut = false;
                    XtraMessageBox.Show("Klik cancel jika tidak ingin me-restore partisi tersebut!", "Konfirmasi Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RichLogs("Pilih file-file ROM yang akan restore! \n", Color.Cyan, true, false);

                    RichLogs("Restore partisi boot... ", Color.Azure, true, false);
                    OpenFileDialog openFileDialogbootimg = new OpenFileDialog()
                    {
                        Title = "Pilih file boot.img",
                        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                        FileName = "*.img*",
                        Filter = "Boot Image |*.img*",
                        FilterIndex = 2,
                        RestoreDirectory = true
                    };
                    if (openFileDialogbootimg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        bootimg = "\"" + openFileDialogbootimg.FileName + "\"";
                        lanjut = true;
                        RichLogs("Ya \n", Color.Cyan, true, false);
                    }
                    else
                    {
                        bootimg = "";
                        RichLogs("Tidak \n", Color.Yellow, true, false);
                    }

                    RichLogs("Restore partisi bootlogo... ", Color.Azure, true, false);
                    OpenFileDialog openFileDialogbootlogo = new OpenFileDialog()
                    {
                        Title = "Pilih file bootlogo.bmp",
                        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                        FileName = "*.bmp*",
                        Filter = "Boot Logo |*.img*",
                        FilterIndex = 2,
                        RestoreDirectory = true
                    };
                    if (openFileDialogbootlogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        bootlogo = "\"" + openFileDialogbootlogo.FileName + "\"";
                        lanjut = true;
                        RichLogs("Ya \n", Color.Cyan, true, false);
                    }
                    else
                    {
                        bootlogo = "";
                        RichLogs("Tidak \n", Color.Yellow, true, false);
                    }

                    RichLogs("Restore partisi cache... ", Color.Azure, true, false);
                    OpenFileDialog openFileDialogcache = new OpenFileDialog()
                    {
                        Title = "Pilih file cache.ext4.tar",
                        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                        FileName = "*cache.ext4.tar*",
                        Filter = "Archive |*.tar* ",
                        FilterIndex = 1,
                        RestoreDirectory = true
                    };
                    if (openFileDialogcache.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        cache = "\"" + openFileDialogcache.FileName + "\"";
                        lanjut = true;
                        RichLogs("Ya \n", Color.Cyan, true, false);
                    }
                    else
                    {
                        cache = "";
                        RichLogs("Tidak \n", Color.Yellow, true, false);
                    }

                    RichLogs("Restore partisi data... ", Color.Azure, true, false);
                    OpenFileDialog openFileDialogdata = new OpenFileDialog()
                    {
                        Title = "Pilih file data.ext4.tar",
                        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                        FileName = "*data.ext4.tar*",
                        Filter = "Archive |*.tar* ",
                        FilterIndex = 1,
                        RestoreDirectory = true
                    };
                    if (openFileDialogdata.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        data = "\"" + openFileDialogdata.FileName + "\"";
                        lanjut = true;
                        RichLogs("Ya \n", Color.Cyan, true, false);
                    }
                    else
                    {
                        data = "";
                        RichLogs("Tidak \n", Color.Yellow, true, false);
                    }

                    RichLogs("Restore partisi system... ", Color.Azure, true, false);
                    OpenFileDialog openFileDialogsystem = new OpenFileDialog()
                    {
                        Title = "Pilih file system.ext4.tar",
                        InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                        FileName = "*system.ext4.tar*",
                        Filter = "Archive |*.tar* ",
                        FilterIndex = 1,
                        RestoreDirectory = true
                    };
                    if (openFileDialogsystem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        system = "\"" + openFileDialogsystem.FileName + "\"";
                        lanjut = true;
                        RichLogs("Ya \n", Color.Cyan, true, false);
                    }
                    else
                    {
                        system = "";
                        RichLogs("Tidak \n", Color.Yellow, true, false);
                    }
                }
                else if (Operation.Contains("BACK-UP ROM"))
                {
                    lanjut = false;

                    FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                    folderDlg.ShowNewFolderButton = true;
                    if (folderDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        foldersave = "";
                        foldersave = folderDlg.SelectedPath;
                        XtraMessageBox.Show("Klik cancel jika tidak ingin membackup partisi tersebut!", "Konfirmasi Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    if (Directory.Exists(foldersave))
                    {
                    RichLogs("Back-up boot.img ... ", Color.Azure, true, false);
                    SaveFileDialog saveFileDialogbootimg = new SaveFileDialog()
                    {
                        Title = "Pilih folder untuk menyimpan file boot.img",
                        InitialDirectory = foldersave,
                        FileName = "boot.img",
                        Filter = "Boot Image |*.img*",
                        FilterIndex = 1,
                        RestoreDirectory = true
                    };
                    if (saveFileDialogbootimg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        foldersavebootimg = "\"" + Path.GetFullPath(saveFileDialogbootimg.FileName) + "\"";
                        lanjut = true;
                        RichLogs("Ya \n", Color.Cyan, true, false);
                    }
                    else
                    {
                        foldersavebootimg = "";
                        RichLogs("Tidak \n", Color.Yellow, true, false);
                    }
                    
                    RichLogs("Back-up bootlogo.bmp ... ", Color.Azure, true, false);
                    SaveFileDialog saveFileDialoglogo = new SaveFileDialog()
                    {
                        Title = "Pilih folder untuk menyimpan file bootlogo.bmp",
                        InitialDirectory = foldersave,
                        FileName = "bootlogo.bmp",
                        Filter = "Image |*.bmp*",
                        FilterIndex = 1,
                        RestoreDirectory = true
                    };
                    if (saveFileDialoglogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        foldersavebootlogo = "\"" + Path.GetFullPath(saveFileDialoglogo.FileName) + "\"";
                        lanjut = true;
                        RichLogs("Ya \n", Color.Cyan, true, false);
                    }
                    else
                    {
                        foldersavebootlogo = "";
                        RichLogs("Tidak \n", Color.Yellow, true, false);
                    }
                    
                    RichLogs("Back-up cache.ext4.tar ... ", Color.Azure, true, false);
                    SaveFileDialog saveFileDialogcache = new SaveFileDialog()
                    {
                        Title = "Pilih folder untuk menyimpan file cache.ext4.tar",
                        InitialDirectory = foldersave,
                        FileName = "cache.ext4.tar",
                        Filter = "Archive |*.tar*",
                        FilterIndex = 1,
                        RestoreDirectory = true
                    };
                    if (saveFileDialogcache.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        foldersavecache = "";
                        foldersavecache = "\"" + Path.GetFullPath(saveFileDialogcache.FileName) + "\"";
                        lanjut = true;
                        RichLogs("Ya \n", Color.Cyan, true, false);
                    }
                    else
                    {
                        foldersavecache = "";
                        RichLogs("Tidak \n", Color.Yellow, true, false);
                    }
                    
                    RichLogs("Back-up data.ext4.tar ... ", Color.Azure, true, false);
                    SaveFileDialog saveFileDialogdata = new SaveFileDialog()
                    {
                        Title = "Pilih folder untuk menyimpan file data.ext4.tar",
                        InitialDirectory = foldersave,
                        FileName = "data.ext4.tar",
                        Filter = "Archive |*.tar*",
                        FilterIndex = 1,
                        RestoreDirectory = true
                    };
                    if (saveFileDialogdata.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        foldersavedata = "\"" + Path.GetFullPath(saveFileDialogdata.FileName) + "\"";
                        lanjut = true;
                        RichLogs("Ya \n", Color.Cyan, true, false);
                    }
                    else
                    {
                        foldersavedata = "";
                        RichLogs("Tidak \n", Color.Yellow, true, false);
                    }

                    RichLogs("Back-up system.ext4.tar ... ", Color.Azure, true, false);
                    SaveFileDialog saveFileDialogsystem = new SaveFileDialog()
                    {
                        Title = "Pilih folder untuk menyimpan file system.ext4.tar",
                        InitialDirectory = foldersave,
                        FileName = "system.ext4.tar",
                        Filter = "Archive |*.tar*",
                        FilterIndex = 1,
                        RestoreDirectory = true
                    };
                    if (saveFileDialogsystem.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        foldersavesystem = "\"" + Path.GetFullPath(saveFileDialogsystem.FileName) + "\"";
                        lanjut = true;
                        RichLogs("Ya \n", Color.Cyan, true, false);
                    }
                    else
                    {
                        foldersavesystem = "";
                        RichLogs("Tidak \n", Color.Yellow, true, false);
                    }
                    

                    }
                    }
                }
                WorkerADB.RunWorkerAsync();
                }
        }

        private void WorkerADB_DoWork(object sender, DoWorkEventArgs e)
        {
            Progress(0);
            if (Consoles.adbdevice(WorkerADB, e))
            {
                if (Operation.Contains("CHECK ADB"))
                {

                    Progress(20);

                    RichLogs("Reading Device Information...", Color.Lime, true, true);

                    RichLogs("Brand: ", Color.Azure, true, false);
                    RichLogs(Consoles.adb("shell getprop ro.product.brand", WorkerADB, e), Color.Cyan, true, true);
                    Progress(30);

                    RichLogs("Model: ", Color.Azure, true, false);
                    RichLogs(Consoles.adb("shell getprop ro.product.model", WorkerADB, e), Color.Cyan, true, true);
                    Progress(35);

                    RichLogs("Android Version: ", Color.Azure, true, false);
                    RichLogs(Consoles.adb("shell getprop ro.build.version.release", WorkerADB, e), Color.Cyan, true, true);
                    Progress(40);

                    RichLogs("Build Number: ", Color.Azure, true, false);
                    RichLogs(Consoles.adb("shell getprop ro.build.display.id", WorkerADB, e), Color.Cyan, true, true);
                    Progress(60);

                    RichLogs("Software Fingerprint: \n", Color.Azure, true, false);
                    RichLogs(Consoles.adb("shell getprop ro.build.fingerprint", WorkerADB, e), Color.Cyan, true, true);
                    Progress(70);

                    if (Consoles.adb("shell if [ -e '/system/xbin/su'  ] ; then echo rooted; fi;", WorkerADB, e).Contains("rooted"))
                    {
                        RichLogs("Root Status: ", Color.Azure, true, false);
                        Progress(90);
                        RichLogs("ROOTED", Color.Lime, true, true);
                        labelControl_root.Invoke(new Action(() => { labelControl_root.Enabled = false; }));
                    }
                    else if (Consoles.adb("shell if [ -e '/sbin/.magisk'  ] ; then echo rooted; fi;", WorkerADB, e).Contains("rooted"))
                    {
                        RichLogs("Root Status: ", Color.Azure, true, false);
                        Progress(90);
                        RichLogs("ROOTED WITH MAGISK", Color.Lime, true, true);
                        labelControl_root.Invoke(new Action(() => { labelControl_root.Enabled = false; }));
                    }
                    else if (Consoles.adb("shell if [ -e '/data/adb/magisk.db'  ] ; then echo rooted; fi;", WorkerADB, e).Contains("rooted"))
                    {
                        RichLogs("Root Status: ", Color.Azure, true, false);
                        Progress(90);
                        RichLogs("ROOTED WITH MAGISK", Color.Lime, true, true);
                        labelControl_root.Invoke(new Action(() => { labelControl_root.Enabled = false; }));
                    }
                    else
                    {
                        RichLogs("Root Status: ", Color.Azure, true, false);
                        Progress(90);
                        labelControl_root.Invoke(new Action(() => { labelControl_root.Enabled = true; }));
                        RichLogs("No ROOT Access", Color.Red, true, true);
                    }
                    Enable_access();
                }

                else if (Operation.Contains("ROOT"))
                {
                    RichLogs("Rooting Andromax Prime...\n\n", Color.Lime, true, false);
                    RichLogs("Jika layar terkunci silahkan buka kunci layar...\n", Color.Cyan, true, false);
                    Progress(20);
                    Consoles.Delay(3);
                    RichLogs("\nProses Root dimulai\n", Color.Lime, true, false);
                    Consoles.adb("shell input keyevent HOME", WorkerADB, e);
                    Progress(40);
                    Consoles.Delay(3);
                    RichLogs("\nCopying update.zip to sdcard...\n", Color.Cyan, true, false);
                    Consoles.adb("push " + Data("update.zip") + " /sdcard/adupsfota/update.zip", WorkerADB, e);
                    Progress(50);
                    Consoles.Delay(3);
                    Consoles.adb("shell settings put global airplane_mode_on 1", WorkerADB, e);
                    Consoles.adb("shell am broadcast -a android.intent.action.AIRPLANE_MODE", WorkerADB, e);
                    RichLogs("Airplane Mode Activated\n", Color.Cyan, true, false);
                    Progress(60);
                    Consoles.Delay(3);
                    RichLogs("Manipulating FOTA Update\n", Color.Cyan, true, false);
                    Consoles.adb("shell pm clear com.smartfren.fota", WorkerADB, e);
                    Progress(80);
                    Consoles.Delay(5);
                    Consoles.adb("shell monkey -p com.smartfren.fota 1", WorkerADB, e);
                    Consoles.adb("shell am start -n com.smartfren.fota/com.adups.fota.FotaPopupUpateActivity", WorkerADB, e);
                    Consoles.adb("shell input keyevent 20", WorkerADB, e);
                    Consoles.adb("shell input keyevent 22", WorkerADB, e);
                    Consoles.adb("shell input keyevent 23", WorkerADB, e);
                    Consoles.adb("shell am start -n com.smartfren.fota/com.adups.fota.FotaInstallDialogActivity", WorkerADB, e);
                    Progress(90);
                    for (int i = 0; i < 15; i++)
                    {
                        Consoles.adb("shell input keyevent 20", WorkerADB, e);
                        Consoles.Delay(1);
                    }
                    RichLogs("Almost done", Color.Cyan, true, true);
                    Consoles.adb("shell input keyevent 23", WorkerADB, e);
                    RichLogs("Andromax Prime Has Been Rooted!", Color.Lime, true, false);
                    RichLogs("\nBrought To You By : \nAdi Subagja @Facebook Group Andromax Prime...", Color.Cyan, true, false);
                }
                else if (Operation.Contains("INSTALL RECOVERY"))
                {

                    RichLogs("Memasang MIUI Recovery\n", Color.Lime, true, false);
                    Progress(20);
                    RichLogs("Menyiapkan file recovery...\n", Color.Azure, true, false);
                    Consoles.adb("push " + Data("MIUI-Recovery.img") + " /sdcard/MIUI-Recovery.img", WorkerADB, e);
                    Consoles.adb("push " + Data("MIUI-Recovery.sh") + " /sdcard/recovery.sh", WorkerADB, e);

                    if (Consoles.adb("shell dd if=/sdcard/MIUI-Recovery.img of=/dev/block/platform/sdio_emmc/by-name/recovery", WorkerADB, e).ToLower().Contains("denied"))
                    {
                        RichLogs("Membuka Jendela Perintah ADB Shell\n", Color.Lime, true, false);
                        Consoles.Delay(5);
                        Progress(40);
                        RichLogs("Mohon Jalankan Perintah berikut ini kemudian tutup CMD :\n", Color.Cyan, true, false);
                        RichLogs("\nadb shell\n", Color.Cyan, true, false);
                        RichLogs("[ENTER from Keyboard]\n", Color.Azure, true, false);
                        RichLogs("\nsu\n", Color.Cyan, true, false);
                        RichLogs("[ENTER from Keyboard]\n", Color.Cyan, true, false);
                        RichLogs("\nsh /sdcard/recovery.sh\n", Color.Cyan, true, false);
                        RichLogs("[ENTER from Keyboard]\n", Color.Azure, true, false);
                        Consoles.adbcmd("");
                    }
                    else
                    {
                        Progress(40);
                    }
                    
                    Progress(80);
                    Consoles.adb("shell exec ./system/bin/reboot recovery", WorkerADB, e);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("RECOVERY FOR DIAG"))
                {
                    RichLogs("Memasang Stok Recovery MOD untuk DIAG Port\n", Color.Lime, true, false);
                    Consoles.Delay(5);
                    Progress(20);
                    RichLogs("Copying Recovery Mod Stock.img device...\n", Color.Cyan, true, false);
                    Consoles.adb("push " + Data("RecoveryModStock.img") + " /sdcard/RecoveryModStock.img", WorkerADB, e);
                    Progress(40);
                    RichLogs("Memasang .... : ", Color.Cyan, true, false);
                    Consoles.adb("shell dd if=/sdcard/RecoveryModStock.img of=/dev/block/platform/sdio_emmc/by-name/recovery", WorkerADB, e);
                    Progress(80);
                    Consoles.adb("shell exec ./system/bin/reboot recovery", WorkerADB, e);
                    RichLogs("Done\n", Color.Lime, true, false);
                    RichLogs("\nInfo : \nGunakan Pandora R21.0.0001 (Gratis di Google juga ada)\nagar dapat terhubung ke Diag PORT SPRD US2 Diag.\n\n", Color.Azure, true, false);
                    RichLogs("Tutorial : \n", Color.Azure, true, false);
                    RichLogs("1. Lepas USB yang tersambung ke Andromax Prime.\n", Color.Azure, true, false);
                    RichLogs("2. Matikan Andromax Prime.\n", Color.Azure, true, false);
                    RichLogs("3. Lepas Baterai Andromax Prime.\n", Color.Azure, true, false);
                    RichLogs("4. Buka Pandora R21.0.0001 & klik connect.\n", Color.Azure, true, false);
                    RichLogs("5. Sambungkan USB ke Andromax Prime tanpa baterai.\n", Color.Azure, true, false);
                    RichLogs("6. Setelah -|+ 3 detik Pasang Baterai Andromax Prime.\n", Color.Azure, true, false);
                    RichLogs("7. Pastikan PORT SPRD US2 Diag terdeteksi juga drivernya\n   telah terinstall dari Device Manager.\n", Color.Azure, true, false);
                    RichLogs("8. Pastikan di Pandora R21.0.0001 enter mode success.\n", Color.Azure, true, false);
                }
                else if (Operation.Contains("REBOOT RECOVERY"))
                {
                    RichLogs("Memulai ulang ke mode recovery : ", Color.Cyan, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    Consoles.adb("shell exec ./system/bin/reboot recovery", WorkerADB, e);
                    Progress(80);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("REBOOT SYSTEM"))
                {
                    RichLogs("Memulai ulang ke mode system : ", Color.Cyan, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    Consoles.adb("shell exec ./system/bin/reboot", WorkerADB, e);
                    Progress(80);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("BACK-UP ROM"))
                {
                    RichLogs("\n", Color.Cyan, true, false); 
                    RichLogs("Membuat file BACK-UP ROM\n", Color.Lime, true, false);
                    Progress(20);
                    if (lanjut)
                    {
                        Consoles.Delay(5);
                        Consoles.adb("shell mount -o rw,remount rootfs /", WorkerADB, e);

                        Progress(35);
                        if (foldersavebootimg != String.Empty)
                        {
                            RichLogs("Mempersiapkan file boot.img \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("shell dd if=/dev/block/platform/sdio_emmc/by-name/boot of=/data/boot.img", WorkerADB, e), Color.Azure, false, true);
                            
                            RichLogs("\n", Color.Cyan, true, false);
                            RichLogs("Menyimpan file boot.img \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("pull /data/boot.img " + foldersavebootimg, WorkerADB, e), Color.Azure, false, true);
                            Consoles.adb("shell rm -fr /data/boot.img", WorkerADB, e);
                        }
                        Progress(40);
                        if (foldersavebootlogo != String.Empty)
                        {
                            RichLogs("Mempersiapkan file bootlogo.bmp \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("shell dd if=/dev/block/platform/sdio_emmc/by-name/logo of=/data/bootlogo.bmp", WorkerADB, e), Color.Azure, false, true);
                            
                            RichLogs("\n", Color.Cyan, true, false);
                            RichLogs("Menyimpan file bootlogo \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("pull /data/bootlogo.bmp " + foldersavebootlogo, WorkerADB, e), Color.Azure, false, true);
                            Consoles.adb("shell rm -fr /data/bootlogo.bmp", WorkerADB, e);
                        }
                        Progress(50);
                        if (foldersavecache != String.Empty)
                        {
                            RichLogs("Mempersiapkan file cache.ext4.tar \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("shell tar -C / -cvf /data/cache.ext4.tar /cache", WorkerADB, e).Replace("cache/", "\ncache/").Replace("data/", "\ndata/").Replace("system/", "\nsystem/"), Color.Azure, false, true);

                            RichLogs("\n", Color.Cyan, true, false);
                            RichLogs("Menyimpan file cache \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("pull /data/cache.ext4.tar " + foldersavecache, WorkerADB, e), Color.Azure, false, true);
                            Consoles.adb("shell rm -fr /data/cache.ext4.tar", WorkerADB, e);
                        }
                        Progress(65);
                        if (foldersavedata != String.Empty)
                        {
                            RichLogs("Mempersiapkan file data.ext4.tar\n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("shell tar -C / --exclude /data/data.ext4.tar -cvf /data/data.ext4.tar /data", WorkerADB, e).Replace("cache/", "\ncache/").Replace("data/", "\ndata/").Replace("system/", "\nsystem/"), Color.Azure, false, true);

                            RichLogs("\n", Color.Cyan, true, false);
                            RichLogs("Menyimpan file data \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("pull /data/data.ext4.tar " + foldersavedata, WorkerADB, e), Color.Azure, false, true);
                            Consoles.adb("shell rm -fr /data/data.ext4.tar", WorkerADB, e);
                        }
                        Progress(80);
                        if (foldersavesystem != String.Empty)
                        {
                            RichLogs("Mempersiapkan file system.ext4.tar\n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("shell tar -C / -cvf /data/system.ext4.tar /system", WorkerADB, e).Replace("cache/", "\ncache/").Replace("data/", "\ndata/").Replace("system/", "\nsystem/"), Color.Azure, false, true);

                            RichLogs("\n", Color.Cyan, true, false);
                            RichLogs("Menyimpan file system \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("pull /data/system.ext4.tar " + foldersavesystem, WorkerADB, e), Color.Azure, false, true);
                            Consoles.adb("shell rm -fr /data/system.ext4.tar", WorkerADB, e);
                        }
                        Progress(90);
                        RichLogs("Back-up ROM : ", Color.Azure, true, false);
                        Consoles.Delay(3);
                        RichLogs("Done\n", Color.Lime, true, false);
                    }
                    else
                    {
                        RichLogs("Silahkan pilih folder penyimpanan ROMnya terlebih dahulu...\n", Color.Red, true, false);
                    }
                }
                else if (Operation.Contains("RESTORE ROM"))
                {
                    RichLogs("\n", Color.Cyan, true, false);
                    RichLogs("Memasang ROM Hasil BACK-UP\n", Color.Lime, true, false);
                    Progress(20);
                    if (lanjut)
                    {
                        Consoles.Delay(5);
                        Consoles.adb("shell mount -o rw,remount rootfs /", WorkerADB, e);

                        Progress(35);
                        if (bootimg != String.Empty && File.Exists(bootimg.Replace("\"", "")))
                        {
                            RichLogs("Menyalin file boot.img \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("push " + bootimg + " /data/boot.img", WorkerADB, e), Color.Azure, false, true);
                            RichLogs("Mengembalikan file boot \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("shell dd if=/data/boot.img of=/dev/block/platform/sdio_emmc/by-name/boot", WorkerADB, e), Color.Azure, false, true);
                            Consoles.adb("shell rm -fr /data/boot.img", WorkerADB, e);
                            RichLogs("\n", Color.Cyan, true, false);
                        }
                        Progress(40);
                        if (bootlogo != String.Empty && File.Exists(bootlogo.Replace("\"", "")))
                        {
                            RichLogs("Menyalin file bootlogo.bmp \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("push " + bootlogo + " /data/bootlogo.bmp", WorkerADB, e), Color.Azure, false, true);
                            RichLogs("Mengembalikan file bootlogo \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("shell dd if=/data/bootlogo.bmp of=/dev/block/platform/sdio_emmc/by-name/logo", WorkerADB, e), Color.Azure, false, true);
                            Consoles.adb("shell rm -fr /data/bootlogo.bmp", WorkerADB, e);
                            RichLogs("\n", Color.Cyan, true, false);
                        }
                        Progress(50);
                        if (cache != String.Empty && File.Exists(cache.Replace("\"", ""))) 
                        {
                            RichLogs("Memformat Partisi Cache\n", Color.Cyan, true, false);
                            Consoles.adb("shell umount /cache", WorkerADB, e);
                            RichLogs(Consoles.adb("shell mke2fs -T ext4 -F /dev/block/platform/sdio_emmc/by-name/cache", WorkerADB, e).Replace("", "\n").Replace("mke2fs 1.40.8 (13-Mar-2008)", "mke2fs 1.40.8 (13-Mar-2008)\n").Replace("systemsFilesystem", "systems\nFilesystem").Replace("(log=2)", "").Replace("Writing inode tables:  ", " Writing inode tables:  \n ").Replace("Writing inode tables: ", " Writing inode tables:  \n ").Replace("\n\n\n\n\n", "\n").Replace("\n\n\n", "\n").Replace("\n\n", "\n").Replace("done                            ", "done\n"), Color.Azure, false, true);
                            RichLogs("\n", Color.Cyan, true, false);

                            RichLogs("Mounting Partisi Cache \n", Color.Cyan, true, false);
                            Consoles.adb("shell mount -o rw,remount /cache", WorkerADB, e);
                            Consoles.adb("shell mount /cache", WorkerADB, e);
                            RichLogs("\n", Color.Cyan, true, false);

                            RichLogs("Menyalin file cache.ext4.tar \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("push " + cache + " /data/cache.ext4.tar", WorkerADB, e), Color.Azure, false, true);

                            RichLogs("Mengembalikan file cache \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("shell tar -C / -xvf /data/cache.ext4.tar", WorkerADB, e).Replace("cache/", "\ncache/").Replace("data/", "\ndata/").Replace("system/", "\nsystem/"), Color.Azure, false, true);
                            Consoles.adb("shell rm -fr /data/cache.ext4.tar", WorkerADB, e);
                            RichLogs("\n", Color.Cyan, true, false);
                        }
                        Progress(65);
                        if (data != String.Empty && File.Exists(data.Replace("\"", "")))
                        {
                            RichLogs("Memformat Partisi Data\n", Color.Cyan, true, false);
                            Consoles.adb("shell umount /data", WorkerADB, e);
                            RichLogs(Consoles.adb("shell mke2fs -T ext4 -F /dev/block/platform/sdio_emmc/by-name/userdata", WorkerADB, e).Replace("", "\n").Replace("mke2fs 1.40.8 (13-Mar-2008)", "mke2fs 1.40.8 (13-Mar-2008)\n").Replace("systemsFilesystem", "systems\nFilesystem").Replace("(log=2)", "").Replace("Writing inode tables:  ", " Writing inode tables:  \n ").Replace("Writing inode tables: ", " Writing inode tables:  \n ").Replace("\n\n\n\n\n", "\n").Replace("\n\n\n", "\n").Replace("\n\n", "\n").Replace("done                            ", "done\n"), Color.Azure, false, true);
                            RichLogs("\n", Color.Cyan, true, false);

                            RichLogs("Mounting Partisi Data \n", Color.Cyan, true, false);
                            Consoles.adb("shell mount -o rw,remount /data", WorkerADB, e);
                            Consoles.adb("shell mount /data", WorkerADB, e);
                            RichLogs("\n", Color.Cyan, true, false);

                            RichLogs("Menyalin file data.ext4.tar \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("push " + data + " /data/data.ext4.tar", WorkerADB, e), Color.Azure, false, true);

                            RichLogs("Mengembalikan file data \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("shell tar -C / -xvf /data/data.ext4.tar", WorkerADB, e).Replace("cache/", "\ncache/").Replace("data/", "\ndata/").Replace("system/", "\nsystem/"), Color.Azure, false, true);
                            Consoles.adb("shell rm -fr /data/data.ext4.tar", WorkerADB, e);
                            RichLogs("\n", Color.Cyan, true, false);
                        }
                        Progress(80);
                        if (system != String.Empty && File.Exists(system.Replace("\"", "")))
                        {
                            RichLogs("Memformat Partisi System\n", Color.Cyan, true, false);
                            Consoles.adb("shell umount /system", WorkerADB, e);
                            RichLogs(Consoles.adb("shell mke2fs -T ext4 -F /dev/block/platform/sdio_emmc/by-name/system", WorkerADB, e).Replace("", "\n").Replace("mke2fs 1.40.8 (13-Mar-2008)", "mke2fs 1.40.8 (13-Mar-2008)\n").Replace("systemsFilesystem", "systems\nFilesystem").Replace("(log=2)", "").Replace("Writing inode tables:  ", " Writing inode tables:  \n ").Replace("\n\n\n\n\n", "\n").Replace("\n\n\n", "\n").Replace("\n\n", "\n").Replace("done                            ", "done\n"), Color.Azure, false, true);
                            RichLogs("\n", Color.Cyan, true, false);

                            RichLogs("Mounting Partisi System \n", Color.Cyan, true, false);
                            Consoles.adb("shell mount -o rw,remount /system", WorkerADB, e);
                            Consoles.adb("shell mount /system", WorkerADB, e);
                            RichLogs("\n", Color.Cyan, true, false);

                            RichLogs("Menyalin file system.ext4.tar \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("push " + system + " /data/system.ext4.tar", WorkerADB, e), Color.Azure, false, true);

                            RichLogs("Mengembalikan file system \n", Color.Cyan, true, false);
                            RichLogs(Consoles.adb("shell tar -C / -xvf /data/system.ext4.tar", WorkerADB, e).Replace("cache/", "\ncache/").Replace("data/", "\ndata/").Replace("system/", "\nsystem/"), Color.Azure, false, true);
                            Consoles.adb("shell rm -fr /data/system.ext4.tar", WorkerADB, e);
                            RichLogs("\n", Color.Cyan, true, false);
                        }
                        Progress(90);
                        RichLogs("Restore ROM : ", Color.Azure, true, false);
                        Consoles.Delay(3);
                        RichLogs("Done\n", Color.Lime, true, false);
                    }
                    else
                    {
                        RichLogs("Silahkan pilih file ROMnya terlebih dahulu...\n", Color.Red, true, false);
                    }
                }
                else if (Operation.Contains("FW 1.9"))
                {
                    RichLogs("Memasang Boot IMG" + Operation + " : ", Color.Lime, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    Consoles.adb("push " + Data("bootfw19.img") + " /sdcard/bootfw19.img", WorkerADB, e);
                    Progress(80);
                    Consoles.adb("shell dd if=/sdcard/bootfw19.img of=/dev/block/platform/sdio_emmc/by-name/boot", WorkerADB, e);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("BOOT IMG MAGISK KK 4.4"))
                {
                    RichLogs("Memasang " + Operation + " : ", Color.Lime, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    Consoles.adb("push " + Data("boot_magisk_44.img") + " /sdcard/boot_magisk_44.img", WorkerADB, e);
                    Consoles.adb("push " + Data("data_magisk_44.ext4.tar") + " /sdcard/data_magisk_44.ext4.tar", WorkerADB, e);
                    Progress(80);
                    Consoles.adb("shell dd if=/sdcard/boot_magisk_44.img of=/dev/block/platform/sdio_emmc/by-name/boot", WorkerADB, e);
                    RichLogs(Consoles.adb("shell tar -C / -xvf /sdcard/data_magisk_44.ext4.tar", WorkerADB, e).Replace("cache/", "\ncache/").Replace("data/", "\ndata/").Replace("system/", "\nsystem/"), Color.Azure, false, true);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("BOOT IMG MAGISK M 6.0"))
                {
                    RichLogs("Memasang " + Operation + " : ", Color.Lime, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    Consoles.adb("push " + Data("boot_magisk_60.img") + " /sdcard/boot_magisk_44.img", WorkerADB, e);
                    Consoles.adb("push " + Data("data_magisk_60.ext4.tar") + " /sdcard/data_magisk_44.ext4.tar", WorkerADB, e);
                    Progress(80);
                    Consoles.adb("shell dd if=/sdcard/boot_magisk_44.img of=/dev/block/platform/sdio_emmc/by-name/boot", WorkerADB, e);
                    RichLogs(Consoles.adb("shell tar -C / -xvf /sdcard/data_magisk_44.ext4.tar", WorkerADB, e).Replace("cache/", "\ncache/").Replace("data/", "\ndata/").Replace("system/", "\nsystem/"), Color.Azure, false, true);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("FW 4.6"))
                {
                    RichLogs("Memasang Boot IMG" + Operation + " : ", Color.Lime, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    Consoles.adb("push " + Data("bootfw46.img") + " /sdcard/bootfw46.img", WorkerADB, e);
                    Progress(80);
                    Consoles.adb("shell dd if=/sdcard/bootfw46.img of=/dev/block/platform/sdio_emmc/by-name/boot", WorkerADB, e);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("FW 5.1"))
                {
                    RichLogs("Memasang Boot IMG" + Operation + " : ", Color.Lime, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    Consoles.adb("push " + Data("bootfw51.img") + " /sdcard/bootfw51.img", WorkerADB, e);
                    Progress(80);
                    Consoles.adb("shell dd if=/sdcard/bootfw51.img of=/dev/block/platform/sdio_emmc/by-name/boot", WorkerADB, e);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("FW 5.1_M"))
                {
                    RichLogs("Memasang Boot IMG" + Operation + " : ", Color.Lime, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    Consoles.adb("push " + Data("bootfw51_M.img") + " /sdcard/bootfw51_M.img", WorkerADB, e);
                    Progress(80);
                    Consoles.adb("shell dd if=/sdcard/bootfw51_M.img of=/dev/block/platform/sdio_emmc/by-name/boot", WorkerADB, e);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("FW 5.4"))
                {
                    RichLogs("Memasang Boot IMG" + Operation + " : ", Color.Lime, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    Consoles.adb("push " + Data("bootfw54.img") + " /sdcard/bootfw54.img", WorkerADB, e);
                    Progress(80);
                    Consoles.adb("shell dd if=/sdcard/bootfw54.img of=/dev/block/platform/sdio_emmc/by-name/boot", WorkerADB, e);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("FW 5.5"))
                {
                    RichLogs("Memasang Boot IMG" + Operation + " : ", Color.Lime, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    Consoles.adb("push " + Data("bootfw55.img") + " /sdcard/bootfw55.img", WorkerADB, e);
                    Progress(80);
                    Consoles.adb("shell dd if=/sdcard/bootfw55.img of=/dev/block/platform/sdio_emmc/by-name/boot", WorkerADB, e);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("FW 5.7"))
                {
                    RichLogs("Memasang Boot IMG" + Operation + " : ", Color.Lime, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    Consoles.adb("push " + Data("bootfw57.img") + " /sdcard/bootfw57.img", WorkerADB, e);
                    Progress(80);
                    Consoles.adb("shell dd if=/sdcard/bootfw57.img of=/dev/block/platform/sdio_emmc/by-name/boot", WorkerADB, e);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("FW 5.7_S"))
                {
                    RichLogs("Memasang Boot IMG" + Operation + " : ", Color.Lime, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    Consoles.adb("push " + Data("bootfw57_S.img") + " /sdcard/bootfw57_S.img", WorkerADB, e);
                    Progress(80);
                    Consoles.adb("shell dd if=/sdcard/bootfw57_S.img of=/dev/block/platform/sdio_emmc/by-name/boot", WorkerADB, e);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("FW 9.9"))
                {
                    RichLogs("Memasang Boot IMG" + Operation + " : ", Color.Lime, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    Consoles.adb("push " + Data("bootfw99.img") + " /sdcard/bootfw99.img", WorkerADB, e);
                    Progress(80);
                    Consoles.adb("shell dd if=/sdcard/bootfw99.img of=/dev/block/platform/sdio_emmc/by-name/boot", WorkerADB, e);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("FW 9.9"))
                {
                    RichLogs("Memasang Boot IMG" + Operation + " : ", Color.Lime, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    Consoles.adb("push " + Data("bootand6.img") + " /sdcard/bootand6.img", WorkerADB, e);
                    Progress(80);
                    Consoles.adb("shell dd if=/sdcard/bootand6.img of=/dev/block/platform/sdio_emmc/by-name/boot", WorkerADB, e);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("UNLOCK BYPASS PIN"))
                {
                    RichLogs("Mulai Membypass PIN SIMCARD \n", Color.Lime, true, false);
                    Progress(40);
                    Consoles.Delay(5);
                    RichLogs("Menyalin File ke Andromax Prime .... \n", Color.Lime, true, false);
                    Consoles.adb("push " + Data("fdl1-sign.bin") + " /sdcard/fdl1-sign.bin", WorkerADB, e);
                    Consoles.adb("push " + Data("fdl2-sign.bin") + " /sdcard/fdl2-sign.bin", WorkerADB, e);
                    Consoles.adb("push " + Data("l_fixnv1.bin.img") + " /sdcard/l_fixnv1.bin", WorkerADB, e);
                    Consoles.adb("push " + Data("l_fixnv2.bin") + " /sdcard/l_fixnv2.bin", WorkerADB, e);
                    Consoles.adb("push " + Data("l_gdsp.bin") + " /sdcard/l_gdsp.bin", WorkerADB, e);
                    Consoles.adb("push " + Data("l_ldsp.bin") + " /sdcard/l_ldsp.bin", WorkerADB, e);
                    Consoles.adb("push " + Data("l_modem.dat") + " /sdcard/l_modem.dat", WorkerADB, e);
                    Consoles.adb("push " + Data("l_runtimenv1.bin") + " /sdcard/l_runtimenv1.bin", WorkerADB, e);
                    Consoles.adb("push " + Data("l_runtimenv2.bin") + " /sdcard/l_runtimenv2.bin", WorkerADB, e);
                    Progress(60);
                    RichLogs("Membuka Andromax Prime .... \n", Color.Lime, true, false);
                    Consoles.adb("shell dd if=/sdcard/fdl1-sign.bin of=/dev/block/mmcblk0boot0", WorkerADB, e);
                    Consoles.adb("shell dd if=/sdcard/fdl2-sign.bin of=/dev/block/mmcblk0boot1", WorkerADB, e);
                    Consoles.adb("shell dd if=/sdcard/l_fixnv1.bin of=/dev/block/platform/sdio_emmc/by-name/l_fixnv1", WorkerADB, e);
                    Consoles.adb("shell dd if=/sdcard/l_fixnv2.bin of=/dev/block/platform/sdio_emmc/by-name/l_fixnv2", WorkerADB, e);
                    Consoles.adb("shell dd if=/sdcard/l_gdsp.bin of=/dev/block/platform/sdio_emmc/by-name/l_gdsp", WorkerADB, e);
                    Consoles.adb("shell dd if=/sdcard/l_ldsp.bin of=/dev/block/platform/sdio_emmc/by-name/l_ldsp", WorkerADB, e);
                    Consoles.adb("shell dd if=/sdcard/l_modem.dat of=/dev/block/platform/sdio_emmc/by-name/l_modem", WorkerADB, e);
                    Consoles.adb("shell dd if=/sdcard/l_runtimenv1.bin of=/dev/block/platform/sdio_emmc/by-name/l_runtimenv1", WorkerADB, e);
                    Consoles.adb("shell dd if=/sdcard/l_runtimenv2.bin of=/dev/block/platform/sdio_emmc/by-name/l_runtimenv2", WorkerADB, e);
                    Progress(80);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("PILIH STANDBY SIM"))
                {
                    Progress(40);
                    Consoles.Delay(5);
                    RichLogs("Membuka Aplikasi .... \n", Color.Lime, true, false);
                    if (Consoles.adb("shell am start -n com.android.phone/com.android.phone.SelectSimCard", WorkerADB, e).Contains("does not exist."))
                    {
                        Consoles.adb("shell am start -n com.sprd.engineermode/com.sprd.engineermode.EngineerModeActivity", WorkerADB, e);
                    }
                    else 
                    {
                        RichLogs("Silahkan Piih SIMCARD : ", Color.Cyan, true, false);
                    }
                    Progress(80);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("UNLOCK VoLTE"))
                {
                    RichLogs("Memulai proses " + Operation + "\n", Color.Lime, true, false);
                    Progress(40);
                    RichLogs("Harap buka kunci layar jika layar terkunci \n", Color.Cyan, true, false);
                    RichLogs("Harap tunggu & pastikan layar Andromax Prime menyala... \n", Color.Azure, true, false);
                    Consoles.Delay(5);
                    Consoles.adb("shell am start -n com.android.phone/com.sprd.phone.VoLTEConfigSettings", WorkerADB, e);
                    Consoles.Delay(1);
                    if (!Consoles.adb("shell getprop ro.build.version.release", WorkerADB, e).Contains("6.0"))
                    {
                        RichLogs("3 - 51089 : ", Color.Cyan, true, false);
                        Consoles.adb("shell input keyevent MENU", WorkerADB, e);
                        Consoles.adb("shell input text insert%s51089", WorkerADB, e);
                        Consoles.adb("shell input keyevent 20", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        RichLogs("OK\n", Color.Lime, true, false);
                        Progress(50);

                        RichLogs("AXIS - 51008 : ", Color.Cyan, true, false);
                        Consoles.adb("shell input keyevent MENU", WorkerADB, e);
                        Consoles.adb("shell input text insert%s51008", WorkerADB, e);
                        Consoles.adb("shell input keyevent 20", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        RichLogs("OK\n", Color.Lime, true, false);
                        Progress(60);

                        RichLogs("Indosat Ooredoo - 51001 : ", Color.Cyan, true, false);
                        Consoles.adb("shell input keyevent MENU", WorkerADB, e);
                        Consoles.adb("shell input text insert%s51001", WorkerADB, e);
                        Consoles.adb("shell input keyevent 20", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        RichLogs("OK\n", Color.Lime, true, false);
                        Progress(70);

                        RichLogs("Indosat IM3 - 51021 : ", Color.Cyan, true, false);
                        Consoles.adb("shell input keyevent MENU", WorkerADB, e);
                        Consoles.adb("shell input text insert%s51021", WorkerADB, e);
                        Consoles.adb("shell input keyevent 20", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        RichLogs("OK\n", Color.Lime, true, false);
                        Progress(75);

                        RichLogs("XL - 51011 : ", Color.Cyan, true, false);
                        Consoles.adb("shell input keyevent MENU", WorkerADB, e);
                        Consoles.adb("shell input text insert%s51011", WorkerADB, e);
                        Consoles.adb("shell input keyevent 20", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        RichLogs("OK\n", Color.Lime, true, false);
                        Progress(80);

                        RichLogs("Telkomsel - 51010 : ", Color.Cyan, true, false);
                        Consoles.adb("shell input keyevent MENU", WorkerADB, e);
                        Consoles.adb("shell input text insert%s51010", WorkerADB, e);
                        Consoles.adb("shell input keyevent 20", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        RichLogs("OK\n", Color.Lime, true, false);
                        Progress(90);

                        Consoles.adb("shell input keyevent BACK", WorkerADB, e);
                    }
                    else
                    {
                        RichLogs("3 - 51089 : ", Color.Cyan, true, false);
                        Consoles.adb("shell input keyevent MENU", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        Consoles.adb("shell input text insert%s51089", WorkerADB, e);
                        Consoles.adb("shell input keyevent 20", WorkerADB, e);
                        Consoles.adb("shell input keyevent 22", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        RichLogs("OK\n", Color.Lime, true, false);
                        Progress(50);

                        RichLogs("AXIS - 51008 : ", Color.Cyan, true, false);
                        Consoles.adb("shell input keyevent MENU", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        Consoles.adb("shell input text insert%s51008", WorkerADB, e);
                        Consoles.adb("shell input keyevent 20", WorkerADB, e);
                        Consoles.adb("shell input keyevent 22", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        RichLogs("OK\n", Color.Lime, true, false);
                        Progress(60);

                        RichLogs("Indosat Ooredoo - 51001 : ", Color.Cyan, true, false);
                        Consoles.adb("shell input keyevent MENU", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        Consoles.adb("shell input text insert%s51001", WorkerADB, e);
                        Consoles.adb("shell input keyevent 20", WorkerADB, e);
                        Consoles.adb("shell input keyevent 22", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        RichLogs("OK\n", Color.Lime, true, false);
                        Progress(70);

                        RichLogs("Indosat IM3 - 51021 : ", Color.Cyan, true, false);
                        Consoles.adb("shell input keyevent MENU", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        Consoles.adb("shell input text insert%s51021", WorkerADB, e);
                        Consoles.adb("shell input keyevent 20", WorkerADB, e);
                        Consoles.adb("shell input keyevent 22", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        RichLogs("OK\n", Color.Lime, true, false);
                        Progress(75);

                        RichLogs("XL - 51011 : ", Color.Cyan, true, false);
                        Consoles.adb("shell input keyevent MENU", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        Consoles.adb("shell input text insert%s51011", WorkerADB, e);
                        Consoles.adb("shell input keyevent 20", WorkerADB, e);
                        Consoles.adb("shell input keyevent 22", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        RichLogs("OK\n", Color.Lime, true, false);
                        Progress(80);

                        RichLogs("Telkomsel - 51010 : ", Color.Cyan, true, false);
                        Consoles.adb("shell input keyevent MENU", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        Consoles.adb("shell input text insert%s51010", WorkerADB, e);
                        Consoles.adb("shell input keyevent 20", WorkerADB, e);
                        Consoles.adb("shell input keyevent 22", WorkerADB, e);
                        Consoles.adb("shell input keyevent 23", WorkerADB, e);
                        RichLogs("OK\n", Color.Lime, true, false);
                        Progress(90);

                        Consoles.adb("shell input keyevent BACK", WorkerADB, e);
                    }
                    
                    RichLogs("\nCatatan : \nKetersediaan jaringan tergantung pada Wilayah Jangkauan & Dukungan Provider Simcard \n", Color.Azure, true, false);
                    RichLogs("\nBrought To You By : \nMuhammad Shubhan @Facebook Group Andromax Prime... ", Color.Azure, true, false);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("INSTALL MIUI RECOVERY - PAKSA"))
                {
                    RichLogs("Memasang MIUI Recovery - PAKSA : ", Color.Cyan, true, false);
                    Progress(20);
                    if (Directory.Exists(USERDIR + "\\.android"))
                    { 

                    }
                    
                    Consoles.adb("shell stop", WorkerADB, e);
                    Consoles.adb("push " + Data("MIUI-Recovery.img") + " /sdcard/MIUI-Recovery.img", WorkerADB, e);
                    Consoles.adb("push " + Data("MIUI-Recovery.sh") + " /sdcard/MIUI-Recovery.sh", WorkerADB, e);

                    Consoles.adb("shell sh ./system/bin/rt.sh", WorkerADB, e);
                    Consoles.adb("shell su -c dd if=/sdcard/recovery.img of=/dev/block/platform/sdio_emmc/by-name/recovery", WorkerADB, e);
                    Consoles.adb("shell su -c sh ./sdcard/recovery.sh", WorkerADB, e);
                    Consoles.adb("shell sh ./sdcard/recovery.sh", WorkerADB, e);

                    if (Consoles.adb("shell dd if=/sdcard/MIUI-Recovery.img of=/dev/block/platform/sdio_emmc/by-name/recovery", WorkerADB, e).ToLower().Contains("denied"))
                    {
                        RichLogs("Membuka Jendela Perintah\n", Color.Yellow, true, false);
                        Consoles.Delay(5);
                        Progress(40);
                        RichLogs("Mohon Jalankan Perintah berikut ini kemudian tutup CMD :\n", Color.Cyan, true, false);
                        RichLogs("\nadb shell\n", Color.Cyan, true, false);
                        RichLogs("[ENTER from Keyboard]\n", Color.Azure, true, false);
                        RichLogs("\nsu\n", Color.Cyan, true, false);
                        RichLogs("[ENTER from Keyboard]\n", Color.Cyan, true, false);
                        RichLogs("\nsh /sdcard/recovery.sh\n", Color.Cyan, true, false);
                        RichLogs("[ENTER from Keyboard]\n", Color.Azure, true, false);
                        Consoles.adbcmd("");
                    }
                    else
                    {
                        Progress(40);
                    }

                    Progress(80);
                    Consoles.adb("shell exec ./system/bin/reboot recovery", WorkerADB, e);
                    Progress(90);
                    RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("INSTALL ROM - TANPA SDCARD"))
                {
                    RichLogs("Memasang Stok ROM Dengan MIUI RECOVERY\n", Color.Lime, true, false);
                    Progress(20);

                        Consoles.Delay(5);
                        Consoles.adb("shell mount -o rw,remount rootfs /", WorkerADB, e);

                        RichLogs("Memformat Partisi Cache\n", Color.Cyan, true, false);
                        Consoles.adb("shell umount /cache", WorkerADB, e);
                        RichLogs(Consoles.adb("shell mke2fs -T ext4 -F /dev/block/platform/sdio_emmc/by-name/cache", WorkerADB, e).Replace("", "\n").Replace("mke2fs 1.40.8 (13-Mar-2008)", "mke2fs 1.40.8 (13-Mar-2008)\n").Replace("systemsFilesystem", "systems\nFilesystem").Replace("(log=2)", "").Replace("Writing inode tables:  ", " Writing inode tables:  \n ").Replace("Writing inode tables: ", " Writing inode tables:  \n ").Replace("\n\n\n\n\n", "\n").Replace("\n\n\n", "\n").Replace("\n\n", "\n").Replace("done                            ", "done\n"), Color.Azure, false, true);
                        RichLogs("\n", Color.Cyan, true, false);

                        RichLogs("Memformat Partisi Data\n", Color.Cyan, true, false);
                        Consoles.adb("shell umount /data", WorkerADB, e);
                        RichLogs(Consoles.adb("shell mke2fs -T ext4 -F /dev/block/platform/sdio_emmc/by-name/userdata", WorkerADB, e).Replace("", "\n").Replace("mke2fs 1.40.8 (13-Mar-2008)", "mke2fs 1.40.8 (13-Mar-2008)\n").Replace("systemsFilesystem", "systems\nFilesystem").Replace("(log=2)", "").Replace("Writing inode tables:  ", " Writing inode tables:  \n ").Replace("Writing inode tables: ", " Writing inode tables:  \n ").Replace("\n\n\n\n\n", "\n").Replace("\n\n\n", "\n").Replace("\n\n", "\n").Replace("done                            ", "done\n"), Color.Azure, false, true);
                        RichLogs("\n", Color.Cyan, true, false);

                        RichLogs("Memformat Partisi System\n", Color.Cyan, true, false);
                        Consoles.adb("shell umount /system", WorkerADB, e);
                        RichLogs(Consoles.adb("shell mke2fs -T ext4 -F /dev/block/platform/sdio_emmc/by-name/system", WorkerADB, e).Replace("", "\n").Replace("mke2fs 1.40.8 (13-Mar-2008)", "mke2fs 1.40.8 (13-Mar-2008)\n").Replace("systemsFilesystem", "systems\nFilesystem").Replace("(log=2)", "").Replace("Writing inode tables:  ", " Writing inode tables:  \n ").Replace("Writing inode tables: ", " Writing inode tables:  \n ").Replace("\n\n\n\n\n", "\n").Replace("\n\n\n", "\n").Replace("\n\n", "\n").Replace("done                            ", "done\n"), Color.Azure, false, true);
                        RichLogs("\n", Color.Cyan, true, false);

                        Progress(30);
                        RichLogs("Mempersiapkan Mounting Partisi ... ", Color.Cyan, true, false);
                        Consoles.Delay(2);
                        Consoles.adb("shell mount -o rw,remount /cache", WorkerADB, e);
                        Consoles.adb("shell mount -o rw,remount /data", WorkerADB, e);
                        Consoles.adb("shell mount /cache", WorkerADB, e);
                        Consoles.adb("shell mount /data", WorkerADB, e);
                        RichLogs("OK \n\n", Color.Lime, true, false);

                        Progress(40);
                        RichLogs("Menyalin file boot.img \n", Color.Cyan, true, false);
                        RichLogs(Consoles.adb("push " + Data("boot.img") + " /data/boot.img", WorkerADB, e), Color.Azure, false, true);
                        
                        Progress(50);
                        RichLogs("Menyalin file bootlogo.bmp \n", Color.Cyan, true, false);
                        RichLogs(Consoles.adb("push " + Data("bootlogo.bmp") + " /data/bootlogo.bmp", WorkerADB, e), Color.Azure, false, true);

                        Progress(60);
                        RichLogs("Menyalin file system \n", Color.Cyan, true, false);
                        RichLogs(Consoles.adb("push " + Data("system.img") + " /data/system.img", WorkerADB, e), Color.Azure, false, true);

                        Progress(70);
                        RichLogs("Memasang file boot \n", Color.Cyan, true, false);
                        RichLogs(Consoles.adb("shell dd if=/data/boot.img of=/dev/block/platform/sdio_emmc/by-name/boot", WorkerADB, e), Color.Azure, false, true);
                        RichLogs("\n", Color.Cyan, true, false);
                    
                        Progress(75);
                        RichLogs("Memasang file bootlogo \n", Color.Cyan, true, false);
                        RichLogs(Consoles.adb("shell dd if=/data/bootlogo.bmp of=/dev/block/platform/sdio_emmc/by-name/logo", WorkerADB, e).Replace("cache/", "\ncache/").Replace("data/", "\ndata/").Replace("system/", "\nsystem/"), Color.Azure, false, true);
                        RichLogs("\n", Color.Cyan, true, false);

                        Progress(80);
                        RichLogs("Memasang file system \n", Color.Cyan, true, false);
                        RichLogs(Consoles.adb("shell dd if=/data/system.img of=/dev/block/platform/sdio_emmc/by-name/system", WorkerADB, e).Replace("cache/", "\ncache/").Replace("data/", "\ndata/").Replace("system/", "\nsystem/"), Color.Azure, false, true);
                        RichLogs("\n", Color.Cyan, true, false);

                        Progress(90);
                        RichLogs("Memasang ROM : ", Color.Azure, true, false);
                        Consoles.adb("shell rm -fr /data/boot.img", WorkerADB, e);
                        Consoles.adb("shell rm -fr /data/bootlogo.bmp", WorkerADB, e);
                        Consoles.adb("shell rm -fr /data/system.img", WorkerADB, e);
                        Consoles.adb("shell mount -o rw,remount /system", WorkerADB, e);
                        Consoles.adb("shell mount /system", WorkerADB, e);
                        RichLogs("Done\n", Color.Lime, true, false);
                }
                else if (Operation.Contains("DEVICE MANAGER"))
                {
                    Process.Start("devmgmt.msc");
                }
            }
            else
            {
                if (Operation.Contains("INSTALL DRIVER"))
                {
                    Process.Start("Drivers\\UniversalAdbDriverSetup.msi");
                }
                else if (Operation.Contains("DEVICE MANAGER"))
                {
                    Process.Start("devmgmt.msc");
                }
                else
                {
                    RichLogs("Error: ", Color.Azure, true, false);
                    RichLogs("     Andromax Prime tidak dapat ditemukan...", Color.Red, true, false);
                    RichLogs("\n            Cek sambungan USB atau INSTALL DRIVER.", Color.Red, true, false);
                }

            }
            Progress(100);
        }

        private void WorkerADB_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            Elapsed(Watch);
            Watch.Stop();
        }

        private void labelControl_STOP_Click(object sender, EventArgs e)
        {
            WorkerADB.CancelAsync();
        }

    }
}