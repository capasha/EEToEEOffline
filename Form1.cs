using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlayerIOClient;
using System.Text.RegularExpressions;
using System.Threading;
using static World;
using EELVL;
using System.IO;
using Microsoft.Win32;

namespace UsernameScraper
{
    public partial class Form1 : Form
    {
        private Semaphore s1 = new Semaphore(0, 1);
        private Semaphore s2 = new Semaphore(0, 1);
        private Semaphore s3 = new Semaphore(0, 1);
        private Semaphore s4 = new Semaphore(0, 1);
        private List<WData> wdata = new List<WData>();
        private List<string> rooms = new List<string>();
        private List<string> favorites = new List<string>();
        private List<string> likes = new List<string>();
        private Dictionary<int, Bitmap> sblocks = new Dictionary<int, Bitmap>();
        private string favowner = "unknown";
        public Form1()
        {

            InitializeComponent();
            this.Text = $"World Downloader - {this.ProductVersion}";
            groupBox1.Location = new Point(12, 60);
            groupBox2.Location = new Point(12, 60);
            worldidGroupBox.Location = new Point(12, 60);
            wdata.Add(new WData() { width = 25, height = 25, totalblocks = 96 });
            wdata.Add(new WData() { width = 40, height = 30, totalblocks = 136 });
            wdata.Add(new WData() { width = 50, height = 50, totalblocks = 196 });
            wdata.Add(new WData() { width = 100, height = 100, totalblocks = 396 });
            wdata.Add(new WData() { width = 110, height = 110, totalblocks = 436 });
            wdata.Add(new WData() { width = 150, height = 150, totalblocks = 596 });
            wdata.Add(new WData() { width = 400, height = 50, totalblocks = 896 });
            wdata.Add(new WData() { width = 636, height = 50, totalblocks = 1368 });
            wdata.Add(new WData() { width = 100, height = 400, totalblocks = 996 });
            wdata.Add(new WData() { width = 200, height = 200, totalblocks = 796 });
            wdata.Add(new WData() { width = 300, height = 300, totalblocks = 1196 });
            wdata.Add(new WData() { width = 400, height = 200, totalblocks = 1196 });
            wdata.Add(new WData() { width = 200, height = 400, totalblocks = 1196 });

            this.ForeColor = Color.White;
            this.BackColor = Color.FromArgb(75, 75, 75);
            ScanButton.FlatStyle = FlatStyle.Flat;
            ScanButton.BackColor = Color.FromArgb(100, 100, 100);
            ScanButton.ForeColor = Color.White;
            menuStrip1.BackColor = Color.FromArgb(90, 90, 90);
            menuStrip1.ForeColor = Color.White;
            int incr2 = 0;
            for(int i = 0;i <  menuStrip1.Items.Count;i++)
            {
                if (menuStrip1.Items[i].Image != null)
                {
                    Bitmap bmpa = (Bitmap)menuStrip1.Items[i].Image;
                    if (!sblocks.ContainsKey(incr2)) sblocks.Add(incr2, bmpa);
                    else if (sblocks.ContainsKey(incr2))
                    {
                        bmpa = sblocks[incr2];
                    }
                    Bitmap bmpa1 = new Bitmap(menuStrip1.Items[i].Image.Width, menuStrip1.Items[i].Image.Height);
                    for (int x = 0; x < menuStrip1.Items[i].Image.Width; x++)
                    {
                        for (int y = 0; y < menuStrip1.Items[i].Image.Height; y++)
                        {
                            if (bmpa.GetPixel(x, y).A > 80)
                            {
                                bmpa1.SetPixel(x, y, Color.White);
                            }
                            else
                            {
                                bmpa1.SetPixel(x, y, menuStrip1.BackColor);
                            }
                        }
                    }
                    menuStrip1.Items[i].Image = bmpa1;
                    incr2 += 1;
                }
            }
            sblocks.Clear();
            foreach (Control cntrl1 in this.Controls)
            {
                if (cntrl1.GetType() == typeof(GroupBox))
                {
                    cntrl1.ForeColor = Color.White;
                    cntrl1.BackColor = Color.FromArgb(75, 75, 75);
                    foreach (Control ctrl in cntrl1.Controls)
                    {
                        ctrl.ForeColor = Color.White;
                        ctrl.BackColor = Color.FromArgb(75, 75, 75);
                        if (ctrl.GetType() == typeof(Label))
                        {
                            ctrl.ForeColor = Color.White;
                        }
                        if (ctrl.GetType() == typeof(RadioButton))
                        {
                            ctrl.BackColor = Color.FromArgb(100, 100, 100);
                            ctrl.ForeColor = Color.White;
                            ((RadioButton)ctrl).FlatStyle = FlatStyle.Flat;
                        }
                        if (ctrl.GetType() == typeof(PictureBox))
                        {
                            ctrl.BackColor = Color.FromArgb(255, 50, 50, 50);

                        }
                    }
                }
            }


        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            logrichTextBox.Clear();
            progressBar1.Value = 0;
            rooms.Clear();
            favorites.Clear();
            likes.Clear();
            if (!string.IsNullOrEmpty(worldidTextBox.Text) && worldIDRadioButton.Checked)
            {
                logrichTextBox.Clear();
                rooms.Clear();
                PlayerIO.QuickConnect.SimpleConnect("everybody-edits-su9rn58o40itdbnw69plyw", Properties.Settings.Default.botlogin, Properties.Settings.Default.botpass, null, (Client client) =>
                {
                    string derpout = "Unknown";

                    RichE.AppendText(logrichTextBox, "Login: Logged in.", Color.LimeGreen);

                    var world = new World(InputType.BigDB, worldidTextBox.Text, client);
                    string title = "Untitled World";
                    if (world.Name != null) title = world.Name;
                    if (world.Owner != null)
                    {
                        client.BigDB.LoadRange("usernames", "owner", null, world.Owner, null, 1, (DatabaseObject[] data) =>
                        {
                            derpout = data[0].Key;
                            s4.Release();
                        }, (PlayerIOError error) => { s4.Release(); });

                    }
                    else
                    {
                        s4.Release();
                    }

                    s4.WaitOne();
                bool empty = false;
                foreach (var val in wdata)
                {
                    if (val.width == world.Width && val.height == world.Height)
                    {
                        if (val.totalblocks == world.Blocks.SelectMany(t => t.Locations).Count())
                        {
                            empty = true;
                        }
                        else if (world.Blocks.SelectMany(t => t.Locations).Count() > val.totalblocks)
                        {
                            empty = false;
                        }
                        else
                        {
                            empty = true;
                        }
                    }

                }
                if (!empty)
                {
                    string name = $"{title.Replace(" ", "_")}_-_{derpout}_-_{worldidTextBox.Text}.eelvl";
                    uint background = 0;
                    if (world.BackgroundColor != null && world.BackgroundColor.ToArgb() != -16777216) background = ColorToUInt(world.BackgroundColor);
                        if (world.Width.ToString() != null && world.Height.ToString() != null)
                        {
                            Level level = new Level(world.Width, world.Height, 0);
                            level.WorldName = title;
                            level.OwnerName = derpout;
                            if (world.Properties.ContainsKey("worldDescription")) level.Description = world.Description;
                            if (world.Properties.ContainsKey("MinimapEnabled")) level.Minimap = (bool)world.Properties["MinimapEnabled"];
                            level.OwnerID = world.Owner;
                            if (world.BackgroundColor.ToArgb() != -16777216) level.BackgroundColor = background;
                                var value = world.Blocks.ToArray();
                                Console.WriteLine(value.Length);
                                foreach (var val in value)
                                {
                                    int block = Convert.ToInt32(val.Type);
                                    foreach (var vale in val.Locations)
                                    {
                                        if (Blocks.IsType(block, Blocks.BlockType.NPC))
                                        {
                                            level[0, vale.X, vale.Y] = new Blocks.NPCBlock(block, val.Name, val.TextMessage1, val.TextMessage2, val.TextMessage3);
                                        }
                                        else if (Blocks.IsType(block, Blocks.BlockType.Normal))
                                        {
                                            if (val.Layer == 1)
                                            {
                                                level[1, vale.X, vale.Y] = new Blocks.Block(block);
                                            }
                                            else
                                            {
                                                level[0, vale.X, vale.Y] = new Blocks.Block(block);
                                            }
                                        }
                                        if (Blocks.IsType(block, Blocks.BlockType.Number))
                                        {
                                            level[0, vale.X, vale.Y] = new Blocks.NumberBlock(block, val.Properties.ContainsKey("goal") ? val.Goal : Convert.ToInt32(val.Id));
                                        }
                                        if (Blocks.IsType(block, Blocks.BlockType.Morphable))
                                        {
                                            level[0, vale.X, vale.Y] = new Blocks.MorphableBlock(block, val.Rotation);
                                        }
                                        if (Blocks.IsType(block, Blocks.BlockType.Enumerable))
                                        {
                                            level[0, vale.X, vale.Y] = new Blocks.EnumerableBlock(block, val.Properties.ContainsKey("rotation") ? val.Rotation : val.Goal);
                                        }
                                        if (Blocks.IsType(block, Blocks.BlockType.Sign))
                                        {
                                            level[0, vale.X, vale.Y] = new Blocks.SignBlock(block, val.Text, val.SignType);
                                        }
                                        if (Blocks.IsType(block, Blocks.BlockType.Rotatable) || Blocks.IsType(block, Blocks.BlockType.RotatableButNotReally))
                                        {
                                            level[0, vale.X, vale.Y] = new Blocks.RotatableBlock(block, val.Rotation);
                                        }
                                        if (Blocks.IsType(block, Blocks.BlockType.Portal))
                                        {
                                            level[0, vale.X, vale.Y] = new Blocks.PortalBlock(block, val.Rotation, Convert.ToInt32(val.Id), Convert.ToInt32(val.Target));
                                        }
                                        if (Blocks.IsType(block, Blocks.BlockType.WorldPortal))
                                        {
                                            level[0, vale.X, vale.Y] = new Blocks.WorldPortalBlock(block, Convert.ToString(val.Target), Convert.ToInt32(val.Id));
                                        }
                                        if (Blocks.IsType(block, Blocks.BlockType.Music))
                                        {
                                            level[0, vale.X, vale.Y] = new Blocks.MusicBlock(block, (int)Convert.ToUInt32(val.Id));
                                        }
                                        if (Blocks.IsType(block, Blocks.BlockType.Label))
                                        {
                                            level[0, vale.X, vale.Y] = new Blocks.LabelBlock(block, val.Text, val.TextColor == null ? "#FFFFFF" : val.TextColor, val.TextWrap == 0 ? 200 : (int)val.TextWrap);
                                        }
                                    }
                                }
                                if (!Directory.Exists($"{Directory.GetCurrentDirectory()}\\{derpout}")) Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\{derpout}");
                                if (!File.Exists($"{Directory.GetCurrentDirectory()}\\{derpout}\\{clearillegal(name, "")}"))
                                {
                                    using (FileStream file = File.OpenWrite($"{Directory.GetCurrentDirectory()}\\{derpout}\\{clearillegal(name, "")}"))
                                    {
                                        level.Save(file);
                                    }
                                }

                                RichE.AppendText(logrichTextBox, "Info: Saved World.", Color.LimeGreen);
                            
                        }
                    }
                }, (PlayerIOError error) =>
                {

                    RichE.AppendText(logrichTextBox, $"Login Error: {error.Message}", Color.Red);

                    if (ScanButton.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            ScanButton.Enabled = true;
                        });
                    }
                    if (worldidTextBox.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            worldidTextBox.Enabled = true;
                        });
                    }
                });
            }

            if (!string.IsNullOrEmpty(emailtextBox.Text) && !string.IsNullOrEmpty(passwordtextBox.Text) && myworldsradioButton.Checked)
            {
                logrichTextBox.Clear();
                progressBar1.Value = 0;
                rooms.Clear();
                favorites.Clear();
                likes.Clear();
                if (EERadioButton.Checked)
                {

                    PlayerIO.QuickConnect.SimpleConnect("everybody-edits-su9rn58o40itdbnw69plyw", emailtextBox.Text, passwordtextBox.Text, null, (Client client) =>
                    {
                        RichE.AppendText(logrichTextBox, "Login: Logged in with email.", Color.LimeGreen);
                        DatabaseObject dbo = client.BigDB.LoadMyPlayerObject();
                        if (dbo.Contains("linkedTo"))
                        {
                            dbo = client.BigDB.Load("playerobjects", dbo["linkedTo"].ToString());
                        }
                        if (dbo != null)
                        {
                            string namen = "unknown";
                            namen = dbo["name"].ToString();
                            foreach (var value in dbo)
                            {
                                if (Regex.IsMatch(value.Key, "world[0-9]{1,4}x[0-9]{1,4}"))
                                {
                                    if (!rooms.Contains(value.Value))
                                    {
                                        rooms.Add(value.Value.ToString());
                                    }
                                }
                                else
                                {
                                    if (value.Key == "betaonlyroom")
                                    {
                                        if (value.Value != null)
                                        {
                                            if (!rooms.Contains(value.Value))
                                            {
                                                rooms.Add(value.Value.ToString());
                                            }
                                        }
                                    }
                                    if (value.Key == "room0")
                                    {
                                        if (value.Value != null)
                                        {
                                            if (!rooms.Contains(value.Value))
                                            {
                                                rooms.Add(value.Value.ToString());
                                            }
                                        }
                                    }
                                    if (value.Key == "worldhome")
                                    {
                                        if (value.Value != null)
                                        {
                                            if (!rooms.Contains(value.Value))
                                            {
                                                rooms.Add(value.Value.ToString());
                                            }
                                        }
                                    }
                                    if (value.Key == "favorites" && cBFav.Checked)
                                    {
                                        foreach (var val in ((DatabaseObject)value.Value).Properties)
                                        {
                                            if (!favorites.Contains(val))
                                            {
                                                favorites.Add(val);
                                            }
                                        }
                                    }
                                    if (value.Key == "likes" && cBLike.Checked)
                                    {
                                        foreach (var val in ((DatabaseObject)value.Value).Properties)
                                        {
                                            if (!likes.Contains(val))
                                            {
                                                likes.Add(val);
                                            }
                                        }
                                    }
                                }
                            }
                            if (rooms.Count > 0)
                            {
                                RichE.AppendText(logrichTextBox, $"Found: {rooms.Count} worlds.", Color.LimeGreen);
                                int incr = 0;
                                string title = "Untitled World";
                                string nname = namen;
                                favowner = namen;
                                RichE.AppendText(logrichTextBox, $"Converting worlds to eelvl..", Color.LimeGreen);
                                foreach (var room in rooms)
                                {
                                    var world = new World(InputType.BigDB, room, client);
                                    if (world != null)
                                    {

                                        if (world.Name != null) title = world.Name;
                                        string name = $"{title.Replace(" ", "_")}_-_{nname}_-_{room}.eelvl";
                                        uint background = 0;
                                        bool empty = false;
                                        foreach (var val in wdata)
                                        {
                                            if (val.width == world.Width && val.height == world.Height)
                                            {
                                                if (val.totalblocks == world.Blocks.SelectMany(t => t.Locations).Count())
                                                {
                                                    empty = true;
                                                }
                                                else if (world.Blocks.SelectMany(t => t.Locations).Count() > val.totalblocks)
                                                {
                                                    empty = false;
                                                }
                                                else
                                                {
                                                    empty = true;
                                                }
                                            }

                                        }
                                        if (!empty)
                                        {
                                            if (world.BackgroundColor != null && world.BackgroundColor.ToArgb() != -16777216) background = ColorToUInt(world.BackgroundColor);

                                            if (world.Width.ToString() != null && world.Height.ToString() != null)
                                            {
                                                Level level = new Level(world.Width, world.Height, 0);

                                                level.WorldName = title;
                                                level.OwnerName = namen;
                                                if (world.Properties.ContainsKey("worldDescription")) level.Description = world.Description;
                                                if (world.Properties.ContainsKey("MinimapEnabled")) level.Minimap = (bool)world.Properties["MinimapEnabled"];
                                                level.OwnerID = world.Owner;
                                                if (world.BackgroundColor.ToArgb() != -16777216) level.BackgroundColor = background;
                                                    var value = world.Blocks.ToArray();
                                                    foreach (var val in value)
                                                    {
                                                        int block = Convert.ToInt32(val.Type);
                                                        foreach (var vale in val.Locations)
                                                        {
                                                            if (Blocks.IsType(block, Blocks.BlockType.NPC))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.NPCBlock(block, val.Name, val.TextMessage1, val.TextMessage2, val.TextMessage3);
                                                            }
                                                            else if (Blocks.IsType(block, Blocks.BlockType.Normal))
                                                            {
                                                                if (val.Layer == 1)
                                                                {
                                                                    level[1, vale.X, vale.Y] = new Blocks.Block(block);
                                                                }
                                                                else
                                                                {
                                                                    level[0, vale.X, vale.Y] = new Blocks.Block(block);
                                                                }
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Number))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.NumberBlock(block, val.Properties.ContainsKey("goal") ? val.Goal : Convert.ToInt32(val.Id));
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Morphable))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.MorphableBlock(block, val.Rotation);
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Enumerable))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.EnumerableBlock(block, val.Properties.ContainsKey("rotation") ? val.Rotation : val.Goal);
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Sign))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.SignBlock(block, val.Text, val.SignType);
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Rotatable) || Blocks.IsType(block, Blocks.BlockType.RotatableButNotReally))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.RotatableBlock(block, val.Rotation);
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Portal))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.PortalBlock(block, val.Rotation, Convert.ToInt32(val.Id), Convert.ToInt32(val.Target));
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.WorldPortal))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.WorldPortalBlock(block, Convert.ToString(val.Target), Convert.ToInt32(val.Id));
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Music))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.MusicBlock(block, (int)Convert.ToUInt32(val.Id));
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Label))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.LabelBlock(block, val.Text, val.TextColor == null ? "#FFFFFF" : val.TextColor, val.TextWrap == 0 ? 200 : (int)val.TextWrap);
                                                            }


                                                        }
                                                    }
                                                    if (!Directory.Exists($"{Directory.GetCurrentDirectory()}\\{nname}")) Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\{nname}");
                                                    if (!File.Exists($"{Directory.GetCurrentDirectory()}\\{nname}\\{clearillegal(name, "")}"))
                                                    {
                                                        using (FileStream file = File.OpenWrite($"{Directory.GetCurrentDirectory()}\\{nname}\\{clearillegal(name, "")}"))
                                                        {
                                                            level.Save(file);
                                                        }
                                                    }
                                                
                                            }
                                            int value1 = rooms.Count - 1;
                                            if (progressBar1.InvokeRequired)
                                            {
                                                this.Invoke((MethodInvoker)delegate
                                                {
                                                    if (value1 == 0) progressBar1.Value = 100;
                                                    else { progressBar1.Value = (incr * 100) / value1; }
                                                });
                                            }
                                        }
                                        int tot = rooms.Count - 1;
                                        if (incr >= tot)
                                        {
                                            RichE.AppendText(logrichTextBox, $"Converting finished!", Color.LimeGreen);
                                        }
                                        incr += 1;
                                    }
                                }
                            }
                            else
                            {
                                RichE.AppendText(logrichTextBox, $"No worlds found.", Color.Red);
                            }
                            if (cBFav.Checked)
                            {
                                if (favorites.Count > 0)
                                {
                                    RichE.AppendText(logrichTextBox, $"Found: {favorites.Count} Favorited worlds.", Color.LimeGreen);
                                    int incr = 0;
                                    string title = "Untitled World";
                                    string nname = namen;
                                    RichE.AppendText(logrichTextBox, $"Converting worlds to eelvl..", Color.LimeGreen);
                                    foreach (var room in favorites)
                                    {
                                        var world = new World(InputType.BigDB, room, client);
                                        string derpout = "unknown";
                                        if (world != null)
                                        {
                                            if (world.Name != null) title = world.Name;
                                            if (world.Owner != null)
                                            {
                                                client.BigDB.LoadRange("usernames", "owner", null, world.Owner, null, 1, (DatabaseObject[] data) =>
                                                {
                                                    derpout = data[0].Key;
                                                    s1.Release();
                                                }, (PlayerIOError error) => { s1.Release(); });

                                            }
                                            else
                                            {
                                                s1.Release();
                                            }
                                            s1.WaitOne();
                                            bool empty = false;
                                            foreach (var val in wdata)
                                            {
                                                if (val.width == world.Width && val.height == world.Height)
                                                {
                                                    if (val.totalblocks == world.Blocks.SelectMany(t => t.Locations).Count())
                                                    {
                                                        empty = true;
                                                    }
                                                    else if (world.Blocks.SelectMany(t => t.Locations).Count() > val.totalblocks)
                                                    {
                                                        empty = false;
                                                    }
                                                    else
                                                    {
                                                        empty = true;
                                                    }
                                                }

                                            }
                                            if (!empty)
                                            {
                                                string name = $"{title.Replace(" ", "_")}_-_{derpout}_-_{room}.eelvl";
                                                uint background = 0;
                                                if (world.BackgroundColor != null && world.BackgroundColor.ToArgb() != -16777216) background = ColorToUInt(world.BackgroundColor);

                                                if (world.Width.ToString() != null && world.Height.ToString() != null)
                                                {
                                                    Level level = new Level(world.Width, world.Height, 0);

                                                    level.WorldName = title;
                                                    level.OwnerName = derpout;
                                                    if (world.Properties.ContainsKey("worldDescription")) level.Description = world.Description;
                                                    if (world.Properties.ContainsKey("MinimapEnabled")) level.Minimap = (bool)world.Properties["MinimapEnabled"];
                                                    level.OwnerID = world.Owner;
                                                    if (world.BackgroundColor.ToArgb() != -16777216) level.BackgroundColor = background;
                                                    var value = world.Blocks.ToArray();
                                                    foreach (var val in value)
                                                    {
                                                        int block = Convert.ToInt32(val.Type);
                                                        foreach (var vale in val.Locations)
                                                        {
                                                            if (Blocks.IsType(block, Blocks.BlockType.NPC))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.NPCBlock(block, val.Name, val.TextMessage1, val.TextMessage2, val.TextMessage3);
                                                            }
                                                            else if (Blocks.IsType(block, Blocks.BlockType.Normal))
                                                            {
                                                                if (val.Layer == 1)
                                                                {
                                                                    level[1, vale.X, vale.Y] = new Blocks.Block(block);
                                                                }
                                                                else
                                                                {
                                                                    level[0, vale.X, vale.Y] = new Blocks.Block(block);
                                                                }
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Number))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.NumberBlock(block, val.Properties.ContainsKey("goal") ? val.Goal : Convert.ToInt32(val.Id));
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Morphable))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.MorphableBlock(block, val.Rotation);
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Enumerable))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.EnumerableBlock(block, val.Properties.ContainsKey("rotation") ? val.Rotation : val.Goal);
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Sign))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.SignBlock(block, val.Text, val.SignType);
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Rotatable) || Blocks.IsType(block, Blocks.BlockType.RotatableButNotReally))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.RotatableBlock(block, val.Rotation);
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Portal))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.PortalBlock(block, val.Rotation, Convert.ToInt32(val.Id), Convert.ToInt32(val.Target));
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.WorldPortal))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.WorldPortalBlock(block, Convert.ToString(val.Target), Convert.ToInt32(val.Id));
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Music))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.MusicBlock(block, (int)Convert.ToUInt32(val.Id));
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Label))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.LabelBlock(block, val.Text, val.TextColor == null ? "#FFFFFF" : val.TextColor, val.TextWrap == 0 ? 200 : (int)val.TextWrap);
                                                            }


                                                        }
                                                    }
                                                    if (!Directory.Exists($"{Directory.GetCurrentDirectory()}\\{favowner}")) Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\{favowner}");
                                                    if (!Directory.Exists($"{Directory.GetCurrentDirectory()}\\{favowner}\\favorites")) Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\{favowner}\\favorites");
                                                    if (!File.Exists($"{Directory.GetCurrentDirectory()}\\{favowner}\\favorites\\{clearillegal(name, "")}"))
                                                    {
                                                        using (FileStream file = File.OpenWrite($"{Directory.GetCurrentDirectory()}\\{favowner}\\favorites\\{clearillegal(name, "")}"))
                                                        {
                                                            level.Save(file);
                                                        }
                                                    }

                                                }
                                                int value1 = favorites.Count - 1;
                                                if (progressBar1.InvokeRequired)
                                                {
                                                    this.Invoke((MethodInvoker)delegate
                                                    {
                                                        if (value1 == 0) progressBar1.Value = 100;
                                                        else { progressBar1.Value = (incr * 100) / value1; }
                                                    });
                                                }
                                            }
                                            int tot = favorites.Count - 1;
                                            if (incr >= tot)
                                            {
                                                RichE.AppendText(logrichTextBox, $"Converting finished!", Color.LimeGreen);
                                            }
                                            incr += 1;
                                        }
                                    }
                                }
                                else
                                {
                                    RichE.AppendText(logrichTextBox, $"No Favorited worlds found.", Color.Red);
                                }
                            }
                            if (cBLike.Checked)
                            {
                                if (likes.Count > 0)
                                {
                                    RichE.AppendText(logrichTextBox, $"Found: {likes.Count} Liked worlds.", Color.LimeGreen);
                                    int incr = 0;
                                    string title = "Untitled World";
                                    string nname = namen;
                                    RichE.AppendText(logrichTextBox, $"Converting worlds to eelvl..", Color.LimeGreen);
                                    foreach (var room in likes)
                                    {
                                        var world = new World(InputType.BigDB, room, client);
                                        string derpout = "unknown";
                                        if (world != null)
                                        {
                                            if (world.Name != null) title = world.Name;
                                            if (world.Owner != null)
                                            {
                                                client.BigDB.LoadRange("usernames", "owner", null, world.Owner, null, 1, (DatabaseObject[] data) =>
                                                {
                                                    derpout = data[0].Key;
                                                    s2.Release();
                                                }, (PlayerIOError error) => { s2.Release(); });

                                            }
                                            else
                                            {
                                                s2.Release();
                                            }
                                            s2.WaitOne();
                                            bool empty = false;
                                            foreach (var val in wdata)
                                            {
                                                if (val.width == world.Width && val.height == world.Height)
                                                {
                                                    if (val.totalblocks == world.Blocks.SelectMany(t => t.Locations).Count())
                                                    {
                                                        empty = true;
                                                    }
                                                    else if (world.Blocks.SelectMany(t => t.Locations).Count() > val.totalblocks)
                                                    {
                                                        empty = false;
                                                    }
                                                    else
                                                    {
                                                        empty = true;
                                                    }
                                                }

                                            }
                                            if (!empty)
                                            {
                                                string name = $"{title.Replace(" ", "_")}_-_{derpout}_-_{room}.eelvl";
                                                uint background = 0;
                                                if (world.BackgroundColor != null && world.BackgroundColor.ToArgb() != -16777216) background = ColorToUInt(world.BackgroundColor);

                                                if (world.Width.ToString() != null && world.Height.ToString() != null)
                                                {
                                                    Level level = new Level(world.Width, world.Height, 0);

                                                    level.WorldName = title;
                                                    level.OwnerName = derpout;
                                                    if (world.Properties.ContainsKey("worldDescription")) level.Description = world.Description;
                                                    if (world.Properties.ContainsKey("MinimapEnabled")) level.Minimap = (bool)world.Properties["MinimapEnabled"];
                                                    level.OwnerID = world.Owner;
                                                    if (world.BackgroundColor.ToArgb() != -16777216) level.BackgroundColor = background;
                                                    var value = world.Blocks.ToArray();
                                                    foreach (var val in value)
                                                    {
                                                        int block = Convert.ToInt32(val.Type);
                                                        foreach (var vale in val.Locations)
                                                        {
                                                            if (Blocks.IsType(block, Blocks.BlockType.NPC))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.NPCBlock(block, val.Name, val.TextMessage1, val.TextMessage2, val.TextMessage3);
                                                            }
                                                            else if (Blocks.IsType(block, Blocks.BlockType.Normal))
                                                            {
                                                                if (val.Layer == 1)
                                                                {
                                                                    level[1, vale.X, vale.Y] = new Blocks.Block(block);
                                                                }
                                                                else
                                                                {
                                                                    level[0, vale.X, vale.Y] = new Blocks.Block(block);
                                                                }
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Number))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.NumberBlock(block, val.Properties.ContainsKey("goal") ? val.Goal : Convert.ToInt32(val.Id));
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Morphable))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.MorphableBlock(block, val.Rotation);
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Enumerable))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.EnumerableBlock(block, val.Properties.ContainsKey("rotation") ? val.Rotation : val.Goal);
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Sign))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.SignBlock(block, val.Text, val.SignType);
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Rotatable) || Blocks.IsType(block, Blocks.BlockType.RotatableButNotReally))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.RotatableBlock(block, val.Rotation);
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Portal))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.PortalBlock(block, val.Rotation, Convert.ToInt32(val.Id), Convert.ToInt32(val.Target));
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.WorldPortal))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.WorldPortalBlock(block, Convert.ToString(val.Target), Convert.ToInt32(val.Id));
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Music))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.MusicBlock(block, (int)Convert.ToUInt32(val.Id));
                                                            }
                                                            if (Blocks.IsType(block, Blocks.BlockType.Label))
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.LabelBlock(block, val.Text, val.TextColor == null ? "#FFFFFF" : val.TextColor, val.TextWrap == 0 ? 200 : (int)val.TextWrap);
                                                            }


                                                        }
                                                    }
                                                    if (!Directory.Exists($"{Directory.GetCurrentDirectory()}\\{favowner}")) Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\{favowner}");
                                                    if (!Directory.Exists($"{Directory.GetCurrentDirectory()}\\{favowner}\\liked")) Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\{favowner}\\liked");
                                                    if (!File.Exists($"{Directory.GetCurrentDirectory()}\\{favowner}\\liked\\{clearillegal(name, "")}"))
                                                    {
                                                        using (FileStream file = File.OpenWrite($"{Directory.GetCurrentDirectory()}\\{favowner}\\liked\\{clearillegal(name, "")}"))
                                                        {
                                                            level.Save(file);
                                                        }
                                                    }

                                                }
                                                int value1 = likes.Count - 1;
                                                if (progressBar1.InvokeRequired)
                                                {
                                                    this.Invoke((MethodInvoker)delegate
                                                    {
                                                        if (value1 == 0) progressBar1.Value = 100;
                                                        else { progressBar1.Value = (incr * 100) / value1; }
                                                    });
                                                }
                                            }
                                            int tot = likes.Count - 1;
                                            if (incr >= tot)
                                            {
                                                RichE.AppendText(logrichTextBox, $"Converting finished!", Color.LimeGreen);
                                            }
                                            incr += 1;
                                        }
                                    }
                                }
                                else
                                {
                                    RichE.AppendText(logrichTextBox, $"No Liked worlds found.", Color.Red);
                                }
                            }
                        }


                    }, (PlayerIOError error) =>
                    {
                        RichE.AppendText(logrichTextBox, $"Login Error: {error.Message}", Color.Red);

                    });

                }
            }
            else if (!string.IsNullOrEmpty(NicknameTextBox.Text) && fromNickradioButton.Checked)
            {
                progressBar1.Value = 0;
                logrichTextBox.Clear();

                bool exists = false;

                PlayerIO.QuickConnect.SimpleConnect("everybody-edits-su9rn58o40itdbnw69plyw", Properties.Settings.Default.botlogin, Properties.Settings.Default.botpass, null, (Client client) =>
                    {

                        RichE.AppendText(logrichTextBox, "Login: Logged in.", Color.LimeGreen);
                        client.BigDB.Load("Usernames", NicknameTextBox.Text.ToLower(), (DatabaseObject db) =>
                          {
                              if (db != null)
                              {
                                  exists = true;
                                  s3.Release();
                              }
                              else
                              {

                                  RichE.AppendText(logrichTextBox, $"Error: Nickname \"{NicknameTextBox.Text}\" doesn't exists", Color.Red);

                                  s3.Release();
                              }

                          }, (PlayerIOError error) =>
                          {


                              RichE.AppendText(logrichTextBox, $"BigDB Error: {error.Message}", Color.Red);


                              s3.Release();
                          });
                        s3.WaitOne();
                        if (exists)
                        {


                            string userid = client.BigDB.Load("Usernames", NicknameTextBox.Text)["owner"].ToString();

                            DatabaseObject dbo = client.BigDB.Load("playerobjects", userid);
                            if (dbo != null)
                            {
                                if (dbo.Properties.Contains("visible"))
                                {
                                    if (Convert.ToBoolean(dbo["visible"]))
                                    {
                                        goto yeah;
                                    }
                                    else
                                    {
                                        if (MessageBox.Show("This user's profile is private. Do you wish to proceed?", "Title", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                        {
                                            goto yeah;
                                        }
                                        else { goto noyeah; }
                                    }
                                }
                            yeah:
                                foreach (var value in dbo)
                                {
                                    if (Regex.IsMatch(value.Key, "world[0-9]{1,4}x[0-9]{1,4}"))
                                    {
                                        if (!rooms.Contains(value.Value))
                                        {
                                            rooms.Add(value.Value.ToString());
                                        }
                                    }
                                    else
                                    {
                                        if (value.Key == "betaonlyroom")
                                        {
                                            if (value.Value != null)
                                            {
                                                if (!rooms.Contains(value.Value))
                                                {
                                                    rooms.Add(value.Value.ToString());
                                                }
                                            }
                                        }
                                        if (value.Key == "room0")
                                        {
                                            if (value.Value != null)
                                            {
                                                if (!rooms.Contains(value.Value))
                                                {
                                                    rooms.Add(value.Value.ToString());
                                                }
                                            }
                                        }
                                        if (value.Key == "worldhome")
                                        {
                                            if (value.Value != null)
                                            {
                                                if (!rooms.Contains(value.Value))
                                                {
                                                    rooms.Add(value.Value.ToString());
                                                }
                                            }
                                        }

                                    }
                                }
                                RichE.AppendText(logrichTextBox, $"Found: {rooms.Count} worlds.", Color.LimeGreen);
                                int incr = 0;
                                string title = "Untitled World";
                                string nname = NicknameTextBox.Text.ToLower();
                                RichE.AppendText(logrichTextBox, $"Converting worlds to eelvl..", Color.LimeGreen);
                                foreach (var room in rooms)
                                {
                                    var world = new World(InputType.BigDB, room, client);
                                    if (world != null)
                                    {
                                        bool empty = false;
                                        foreach (var val in wdata)
                                        {
                                            if (val.width == world.Width && val.height == world.Height)
                                            {
                                                if (val.totalblocks == world.Blocks.SelectMany(t => t.Locations).Count())
                                                {
                                                    empty = true;
                                                }
                                                else if (world.Blocks.SelectMany(t => t.Locations).Count() > val.totalblocks)
                                                {
                                                    empty = false;
                                                }
                                                else
                                                {
                                                    empty = true;
                                                }
                                            }

                                        }
                                        if (!empty)
                                        {
                                            if (world.Name != null) title = world.Name;
                                            string name = $"{title.Replace(" ", "_")}_-_{nname}_-_{room}.eelvl";
                                            uint background = 0;
                                            if (world.BackgroundColor != null && world.BackgroundColor.ToArgb() != -16777216) background = ColorToUInt(world.BackgroundColor);

                                            if (world.Width.ToString() != null && world.Height.ToString() != null)
                                            {
                                                Level level = new Level(world.Width, world.Height, 0);

                                                level.WorldName = title;
                                                level.OwnerName = NicknameTextBox.Text.ToLower();
                                                if (world.Properties.ContainsKey("worldDescription")) level.Description = world.Description;
                                                if (world.Properties.ContainsKey("MinimapEnabled")) level.Minimap = (bool)world.Properties["MinimapEnabled"];
                                                level.OwnerID = world.Owner;
                                                if (world.BackgroundColor.ToArgb() != -16777216) level.BackgroundColor = background;
                                                var value = world.Blocks.ToArray();
                                                foreach (var val in value)
                                                {
                                                    int block = Convert.ToInt32(val.Type);
                                                    foreach (var vale in val.Locations)
                                                    {
                                                        if (Blocks.IsType(block, Blocks.BlockType.NPC))
                                                        {
                                                            level[0, vale.X, vale.Y] = new Blocks.NPCBlock(block, val.Name, val.TextMessage1, val.TextMessage2, val.TextMessage3);
                                                        }
                                                        else if (Blocks.IsType(block, Blocks.BlockType.Normal))
                                                        {
                                                            if (val.Layer == 1)
                                                            {
                                                                level[1, vale.X, vale.Y] = new Blocks.Block(block);
                                                            }
                                                            else
                                                            {
                                                                level[0, vale.X, vale.Y] = new Blocks.Block(block);
                                                            }
                                                        }
                                                        if (Blocks.IsType(block, Blocks.BlockType.Number))
                                                        {
                                                            level[0, vale.X, vale.Y] = new Blocks.NumberBlock(block, val.Properties.ContainsKey("goal") ? val.Goal : Convert.ToInt32(val.Id));
                                                        }
                                                        if (Blocks.IsType(block, Blocks.BlockType.Morphable))
                                                        {
                                                            level[0, vale.X, vale.Y] = new Blocks.MorphableBlock(block, val.Rotation);
                                                        }
                                                        if (Blocks.IsType(block, Blocks.BlockType.Enumerable))
                                                        {
                                                            level[0, vale.X, vale.Y] = new Blocks.EnumerableBlock(block, val.Properties.ContainsKey("rotation") ? val.Rotation : val.Goal);
                                                        }
                                                        if (Blocks.IsType(block, Blocks.BlockType.Sign))
                                                        {
                                                            level[0, vale.X, vale.Y] = new Blocks.SignBlock(block, val.Text, val.SignType);
                                                        }
                                                        if (Blocks.IsType(block, Blocks.BlockType.Rotatable) || Blocks.IsType(block, Blocks.BlockType.RotatableButNotReally))
                                                        {
                                                            level[0, vale.X, vale.Y] = new Blocks.RotatableBlock(block, val.Rotation);
                                                        }
                                                        if (Blocks.IsType(block, Blocks.BlockType.Portal))
                                                        {
                                                            level[0, vale.X, vale.Y] = new Blocks.PortalBlock(block, val.Rotation, Convert.ToInt32(val.Id), Convert.ToInt32(val.Target));
                                                        }
                                                        if (Blocks.IsType(block, Blocks.BlockType.WorldPortal))
                                                        {
                                                            level[0, vale.X, vale.Y] = new Blocks.WorldPortalBlock(block, Convert.ToString(val.Target), Convert.ToInt32(val.Id));
                                                        }
                                                        if (Blocks.IsType(block, Blocks.BlockType.Music))
                                                        {
                                                            level[0, vale.X, vale.Y] = new Blocks.MusicBlock(block, (int)Convert.ToUInt32(val.Id));
                                                        }
                                                        if (Blocks.IsType(block, Blocks.BlockType.Label))
                                                        {
                                                            level[0, vale.X, vale.Y] = new Blocks.LabelBlock(block, val.Text, val.TextColor == null ? "#FFFFFF" : val.TextColor, val.TextWrap == 0 ? 200 : (int)val.TextWrap);
                                                        }


                                                    }
                                                }
                                                if (!Directory.Exists($"{Directory.GetCurrentDirectory()}\\{nname}")) Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\{nname}");
                                                if (!File.Exists($"{Directory.GetCurrentDirectory()}\\{nname}\\{clearillegal(name, "")}"))
                                                {
                                                    using (FileStream file = File.OpenWrite($"{Directory.GetCurrentDirectory()}\\{nname}\\{clearillegal(name, "")}"))
                                                    {
                                                        level.Save(file);
                                                    }
                                                }
                                            }
                                        }
                                        int value1 = rooms.Count - 1;
                                        if (progressBar1.InvokeRequired)
                                        {
                                            this.Invoke((MethodInvoker)delegate
                                            {
                                                if (value1 == 0) progressBar1.Value = 100;
                                                else { progressBar1.Value = (incr * 100) / value1; }
                                            });
                                        }
                                    }
                                    int tot = rooms.Count - 1;
                                    if (incr >= tot)
                                    {
                                        RichE.AppendText(logrichTextBox, $"Converting finished!", Color.LimeGreen);
                                    }
                                    incr += 1;
                                }



                            }
                        noyeah:
                            Console.WriteLine("lol");
                        }
                    }, (PlayerIOError error) =>
                 {
                     RichE.AppendText(logrichTextBox, $"Login Error: {error.Message}", Color.Red);

                     if (ScanButton.InvokeRequired)
                     {
                         this.Invoke((MethodInvoker)delegate
                         {
                             ScanButton.Enabled = true;
                         });
                     }
                     if (NicknameTextBox.InvokeRequired)
                     {
                         this.Invoke((MethodInvoker)delegate
                         {
                             NicknameTextBox.Enabled = true;
                         });
                     }
                 });
            }
        }

        public static string clearillegal(string filename, string replaceChar)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(filename, replaceChar);
        }


        private void MyworldsradioButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            worldidGroupBox.Visible = false;
        }

        private void FromNickradioButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
            worldidGroupBox.Visible = false;
        }

        private void WorldIDRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            worldidGroupBox.Visible = true;
        }
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settingss openit = new Settingss();
            openit.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private string RandomString(int length)
        {
            const string chars = "abcdefghijlmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[new Random().Next(s.Length)]).ToArray());
        }


        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.ShowDialog();
        }

        private void EERadioButton_CheckedChanged(object sender, EventArgs e)
        {
            emaillabel.Text = "E-mail:";
            passwordlabel.Text = "Password";
        }


        private uint ColorToUInt(Color color)
        {
            return (uint)((color.A << 24) | (color.R << 16) |
                          (color.G << 8) | (color.B << 0));
        }


        private void cBEmpty_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.emptyIgnore = ((CheckBox)sender).Checked;
            Properties.Settings.Default.Save();
        }
    }
    public static class RichE
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            if (box.InvokeRequired)
            {
                box.Invoke((MethodInvoker)delegate
                {
                    box.SelectionStart = box.TextLength;
                    box.SelectionLength = 0;

                    box.SelectionColor = color;
                    box.AppendText(text + "\n");
                    box.SelectionColor = box.ForeColor;
                });
            }
            else
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;

                box.SelectionColor = color;
                box.AppendText(text + "\n");
                box.SelectionColor = box.ForeColor;
            }
        }
    }
    public class WData
    {
        public int width { get; set; }
        public int height { get; set; }
        public int totalblocks { get; set; }
    }

}

