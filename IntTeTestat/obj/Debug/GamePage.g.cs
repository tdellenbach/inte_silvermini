﻿#pragma checksum "C:\Users\pangody\Documents\cvswork\IntTe\Miniprojekt2\inte_silvermini\IntTeTestat\GamePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0278EF7E14428AB638693CDD28A61C02"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.1
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace IntTeTestat {
    
    
    public partial class GamePage : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock WelcomeTextBlock;
        
        internal System.Windows.Controls.TextBlock InstructionTextBlock;
        
        internal System.Windows.Controls.TextBox InputTextBox;
        
        internal System.Windows.Controls.Button SendGuessButton;
        
        internal System.Windows.Controls.TextBlock LabelTextBlock;
        
        internal System.Windows.Controls.ListBox GuessesListBox;
        
        internal System.Windows.Controls.ListBox PlayersListBox;
        
        internal System.Windows.Controls.TextBlock GuessesTextBlock;
        
        internal System.Windows.Controls.TextBlock PlayersTextBlock;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/IntTeTestat;component/GamePage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.WelcomeTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("WelcomeTextBlock")));
            this.InstructionTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("InstructionTextBlock")));
            this.InputTextBox = ((System.Windows.Controls.TextBox)(this.FindName("InputTextBox")));
            this.SendGuessButton = ((System.Windows.Controls.Button)(this.FindName("SendGuessButton")));
            this.LabelTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("LabelTextBlock")));
            this.GuessesListBox = ((System.Windows.Controls.ListBox)(this.FindName("GuessesListBox")));
            this.PlayersListBox = ((System.Windows.Controls.ListBox)(this.FindName("PlayersListBox")));
            this.GuessesTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("GuessesTextBlock")));
            this.PlayersTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("PlayersTextBlock")));
        }
    }
}
