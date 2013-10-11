/* Deck.js Helper
 * Copyright (c) 2013 Benjamin Röjder Delnavaz
 * Licensed under the MIT license. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cottle;
using Cottle.Documents;
using Cottle.Scopes;

namespace DeckjsHelper
{
    public partial class MainWindow : Form
    {
        public Dictionary<string, string> extensions;
        public Dictionary<string, string> styles;
        public Dictionary<string, string> snippets;
        public Dictionary<string, string> transitions;

        public MainWindow()
        {
            InitializeComponent();

            extensions = new Dictionary<string, string>();
            styles = new Dictionary<string, string>();
            transitions = new Dictionary<string, string>();
            snippets = new Dictionary<string, string>();

            var deckjsLocation = Properties.Settings.Default.DeckjsLocation;

            if (string.IsNullOrEmpty(deckjsLocation))
            {
                MessageBox.Show("Please choose where deck.js is located.");
                ChooseDeckjsLocation();
            }
            else
            {
                djlTextBox.Text = deckjsLocation;
                ReloadExtensions();
                LoadSnippets();
                ReloadThemes();
            }
        }

        public void ChooseDeckjsLocation()
        {
            var results = folderBrowserDialog.ShowDialog(this);
            if (results == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                if (string.IsNullOrEmpty(path))
                {
                    MessageBox.Show("Path cannot be empty.");
                    return;
                }

                if (!File.Exists(Path.Combine(path, "core", "deck.core.js")))
                {
                    MessageBox.Show("Selected folder does not seem to be a deck.js folder.");
                    return;
                }

                djlTextBox.Text = path;

                Properties.Settings.Default.DeckjsLocation = path;
                Properties.Settings.Default.Save();

                ReloadExtensions();
                LoadSnippets();
                ReloadThemes();
            }
        }

        public void LoadSnippets()
        {
            if (string.IsNullOrEmpty(djlTextBox.Text))
                return;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "snippets");
            var extSnippets = Directory.EnumerateFiles(path);

            foreach (var snippet in extSnippets)
            {
                string snippetName = Path.GetFileNameWithoutExtension(snippet);
                snippets.Add(snippetName, File.ReadAllText(snippet));
            }
        }

        public string CreateDocument()
        {
            IDocument document;
            IScope scope;

            using (StreamReader template = new StreamReader(new FileStream("template.html", FileMode.Open), Encoding.UTF8))
            {
                document = new SimpleDocument(template);
            }

            scope = new DefaultScope();

            scope["slideTitle"] = titleTextBox.Text;

            int numExts = extensionsListBox.SelectedItems.Count;

            var stylesheets = new Value[numExts];
            var scripts = new Value[numExts];
            var extSnippets = new Dictionary<Value, Value>();
            int i = 0;
            foreach (string extName in extensionsListBox.SelectedItems)
            {
                stylesheets[i] = extensions[extName] + ".css";
                scripts[i] = extensions[extName] + ".js";

                var snippetName = "deck." + extName;

                if (snippets.ContainsKey(snippetName))
                    extSnippets.Add(snippetName, snippets[snippetName]);

                i++;
            }

            scope["extensionStylesheets"] = stylesheets;
            scope["extensionScripts"] = scripts;
            scope["extensionSnippets"] = extSnippets;
            scope["styleTheme"] = styles[(string)stylesListBox.SelectedItem];
            scope["transitionTheme"] = transitions[(string)transitionsListBox.SelectedItem];

            return document.Render(scope);
        }

        public void CreateNewSlide(string outputPath)
        {
            Directory.CreateDirectory(outputPath);
            Directory.CreateDirectory(Path.Combine(outputPath, "vendor"));
            Directory.CreateDirectory(Path.Combine(outputPath, "core"));
            Directory.CreateDirectory(Path.Combine(outputPath, "themes", "style"));
            Directory.CreateDirectory(Path.Combine(outputPath, "themes", "transition"));
            Directory.CreateDirectory(Path.Combine(outputPath, "extensions"));

            var deckjsLocation = djlTextBox.Text;

            // Vendor
            File.Copy(
                Path.Combine(deckjsLocation, "modernizr.custom.js"),
                Path.Combine(outputPath, "vendor", "modernizr.custom.js")
            );
            File.Copy(
                Path.Combine(deckjsLocation, "jquery-1.7.2.min.js"),
                Path.Combine(outputPath, "vendor", "jquery-1.7.2.min.js")
            );

            // Core
            File.Copy(
                Path.Combine(deckjsLocation, "core", "deck.core.js"),
                Path.Combine(outputPath, "core", "deck.core.js")
            );
            File.Copy(
                Path.Combine(deckjsLocation, "core", "deck.core.css"),
                Path.Combine(outputPath, "core", "deck.core.css")
            );

            // All Themes
            foreach (var themeDir in Directory.EnumerateDirectories(Path.Combine(deckjsLocation, "themes")))
            {
                string themeType = themeDir.Split(Path.DirectorySeparatorChar).Last();
                foreach (var file in Directory.EnumerateFiles(themeDir))
                {
                    if (Path.GetExtension(file) == ".css")
                    {
                        Console.WriteLine(Path.Combine(outputPath, "themes", themeType, Path.GetFileName(file)));
                        File.Copy(
                            file,
                            Path.Combine(outputPath, "themes", themeType, Path.GetFileName(file))
                        );
                    }
                }
            }

            // Selected Extensions
            foreach (var extDir in Directory.EnumerateDirectories(Path.Combine(deckjsLocation, "extensions")))
            {
                string extName = extDir.Split(Path.DirectorySeparatorChar).Last();

                foreach (string item in extensionsListBox.SelectedItems)
                {
                    if (item == extName)
                    {
                        foreach (var file in Directory.EnumerateFiles(extDir))
                        {
                            Console.WriteLine(Path.GetExtension(file));
                            if (Path.GetExtension(file) == ".css" ||
                                Path.GetExtension(file) == ".js")
                            {
                                Console.WriteLine(Path.Combine(outputPath, "extensions", extName, Path.GetFileName(file)));
                                Directory.CreateDirectory(Path.Combine(outputPath, "extensions", extName));
                                File.Copy(
                                    file,
                                    Path.Combine(outputPath, "extensions", extName, Path.GetFileName(file))
                                );
                            }
                        }
                    }
                }
            }

            // Slide document
            using (StreamWriter output = new StreamWriter(
                new FileStream(Path.Combine(outputPath, "index.html"), FileMode.CreateNew), Encoding.UTF8))
            {
                output.Write(CreateDocument());
            }
            
        }

        public void ReloadExtensions()
        {
            if (string.IsNullOrEmpty(djlTextBox.Text))
                return;

            string path = Path.Combine(djlTextBox.Text, "extensions");
            var extensionFolders = Directory.EnumerateDirectories(path);

            extensionsListBox.Items.Clear();
            extensions.Clear();

            foreach (var extensionFilePath in extensionFolders)
            {
                string extensionName = extensionFilePath.Split(Path.DirectorySeparatorChar).Last();
                extensions.Add(extensionName, "extensions/" + extensionName + "/deck." + extensionName);
                extensionsListBox.Items.Add(extensionName);
            }
        }

        public void ReloadThemes()
        {
            ReloadStyles();
            ReloadTransitions();
        }

        public void ReloadStyles()
        {
            if (string.IsNullOrEmpty(djlTextBox.Text))
                return;

            string path = Path.Combine(djlTextBox.Text, "themes", "style");
            var styleFiles = Directory.EnumerateFiles(path, "*.css");

            stylesListBox.Items.Clear();
            styles.Clear();

            styles.Add("none", "");
            stylesListBox.Items.Add("none");

            foreach (var stylePath in styleFiles)
            {
                string styleName = Path.GetFileNameWithoutExtension(stylePath);
                styles.Add(styleName, 
                    "themes/style/" + Path.GetFileName(stylePath));
                stylesListBox.Items.Add(styleName);
            }

            stylesListBox.SelectedIndex = 0;
        }

        public void ReloadTransitions()
        {
            if (string.IsNullOrEmpty(djlTextBox.Text))
                return;

            string path = Path.Combine(djlTextBox.Text, "themes", "transition");
            var transitionFiles = Directory.EnumerateFiles(path, "*.css");

            transitionsListBox.Items.Clear();
            transitions.Clear();

            transitions.Add("none", "");
            transitionsListBox.Items.Add("none");

            foreach (var transitionPath in transitionFiles)
            {
                string transitionName = Path.GetFileNameWithoutExtension(transitionPath);
                transitions.Add(transitionName, 
                    "themes/transition/" + Path.GetFileName(transitionPath));
                transitionsListBox.Items.Add(transitionName);
            }

            transitionsListBox.SelectedIndex = 0;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(djlTextBox.Text))
            {
                MessageBox.Show("You need to choose a deck.js folder first.");

                return;
            }

            if (string.IsNullOrEmpty(outputTextBox.Text))
            {
                MessageBox.Show("You need to choose an output folder first.");

                return;
            }

            CreateNewSlide(outputTextBox.Text);
        }

        private void djlBrowseButton_Click(object sender, EventArgs e)
        {
            ChooseDeckjsLocation();
        }

        private void outputBrowseButton_Click(object sender, EventArgs e)
        {
            var results = folderBrowserDialog.ShowDialog();
            if (results == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                outputTextBox.Text = path;
            }
        }

        private void extsReloadButton_Click(object sender, EventArgs e)
        {
            ReloadExtensions();
        }

        private void stylesReloadButton_Click(object sender, EventArgs e)
        {
            ReloadStyles();
        }

        private void transitionsReloadButton_Click(object sender, EventArgs e)
        {
            ReloadTransitions();
        }
    }
}
