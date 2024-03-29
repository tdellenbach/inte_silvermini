﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 4.0.50826.0
// 
namespace IntTeTestat.GuessServiceReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Guess", Namespace="http://schemas.datacontract.org/2004/07/IntTeTestat.Web.Util")]
    public partial class Guess : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string _guessValueField;
        
        private string _playerNameField;
        
        private IntTeTestat.GuessServiceReference.GuessTipp Tippk__BackingFieldField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string _guessValue {
            get {
                return this._guessValueField;
            }
            set {
                if ((object.ReferenceEquals(this._guessValueField, value) != true)) {
                    this._guessValueField = value;
                    this.RaisePropertyChanged("_guessValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string _playerName {
            get {
                return this._playerNameField;
            }
            set {
                if ((object.ReferenceEquals(this._playerNameField, value) != true)) {
                    this._playerNameField = value;
                    this.RaisePropertyChanged("_playerName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Tipp>k__BackingField", IsRequired=true)]
        public IntTeTestat.GuessServiceReference.GuessTipp Tippk__BackingField {
            get {
                return this.Tippk__BackingFieldField;
            }
            set {
                if ((this.Tippk__BackingFieldField.Equals(value) != true)) {
                    this.Tippk__BackingFieldField = value;
                    this.RaisePropertyChanged("Tippk__BackingField");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GuessTipp", Namespace="http://schemas.datacontract.org/2004/07/IntTeTestat.Web.Util")]
    public enum GuessTipp : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ToLow = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ToHigh = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Correct = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Others = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="GuessServiceReference.GuessService", CallbackContract=typeof(IntTeTestat.GuessServiceReference.GuessServiceCallback))]
    public interface GuessService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="urn:GuessService/Conntect")]
        System.IAsyncResult BeginConntect(System.AsyncCallback callback, object asyncState);
        
        void EndConntect(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="urn:GuessService/AddName")]
        System.IAsyncResult BeginAddName(string name, System.AsyncCallback callback, object asyncState);
        
        void EndAddName(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="urn:GuessService/Guess")]
        System.IAsyncResult BeginGuess(int value, System.AsyncCallback callback, object asyncState);
        
        void EndGuess(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="urn:GuessService/QuitConnect")]
        System.IAsyncResult BeginQuitConnect(System.AsyncCallback callback, object asyncState);
        
        void EndQuitConnect(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GuessServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="urn:GuessService/StartGame")]
        void StartGame(System.Collections.ObjectModel.ObservableCollection<string> players, string playerName);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="urn:GuessService/GameOver")]
        void GameOver(bool victory, System.Collections.ObjectModel.ObservableCollection<IntTeTestat.GuessServiceReference.Guess> playedValues);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="urn:GuessService/ConnectCanceled")]
        void ConnectCanceled();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="urn:GuessService/PlayerLeft")]
        void PlayerLeft(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="urn:GuessService/PlayerGuess")]
        void PlayerGuess(IntTeTestat.GuessServiceReference.Guess guess);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GuessServiceChannel : IntTeTestat.GuessServiceReference.GuessService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GuessServiceClient : System.ServiceModel.DuplexClientBase<IntTeTestat.GuessServiceReference.GuessService>, IntTeTestat.GuessServiceReference.GuessService {
        
        private BeginOperationDelegate onBeginConntectDelegate;
        
        private EndOperationDelegate onEndConntectDelegate;
        
        private System.Threading.SendOrPostCallback onConntectCompletedDelegate;
        
        private BeginOperationDelegate onBeginAddNameDelegate;
        
        private EndOperationDelegate onEndAddNameDelegate;
        
        private System.Threading.SendOrPostCallback onAddNameCompletedDelegate;
        
        private BeginOperationDelegate onBeginGuessDelegate;
        
        private EndOperationDelegate onEndGuessDelegate;
        
        private System.Threading.SendOrPostCallback onGuessCompletedDelegate;
        
        private BeginOperationDelegate onBeginQuitConnectDelegate;
        
        private EndOperationDelegate onEndQuitConnectDelegate;
        
        private System.Threading.SendOrPostCallback onQuitConnectCompletedDelegate;
        
        private bool useGeneratedCallback;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public GuessServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public GuessServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public GuessServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GuessServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GuessServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public GuessServiceClient(string endpointConfigurationName) : 
                this(new GuessServiceClientCallback(), endpointConfigurationName) {
        }
        
        private GuessServiceClient(GuessServiceClientCallback callbackImpl, string endpointConfigurationName) : 
                this(new System.ServiceModel.InstanceContext(callbackImpl), endpointConfigurationName) {
            useGeneratedCallback = true;
            callbackImpl.Initialize(this);
        }
        
        public GuessServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                this(new GuessServiceClientCallback(), binding, remoteAddress) {
        }
        
        private GuessServiceClient(GuessServiceClientCallback callbackImpl, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                this(new System.ServiceModel.InstanceContext(callbackImpl), binding, remoteAddress) {
            useGeneratedCallback = true;
            callbackImpl.Initialize(this);
        }
        
        public GuessServiceClient() : 
                this(new GuessServiceClientCallback()) {
        }
        
        private GuessServiceClient(GuessServiceClientCallback callbackImpl) : 
                this(new System.ServiceModel.InstanceContext(callbackImpl)) {
            useGeneratedCallback = true;
            callbackImpl.Initialize(this);
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> ConntectCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> AddNameCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> GuessCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> QuitConnectCompleted;
        
        public event System.EventHandler<StartGameReceivedEventArgs> StartGameReceived;
        
        public event System.EventHandler<GameOverReceivedEventArgs> GameOverReceived;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> ConnectCanceledReceived;
        
        public event System.EventHandler<PlayerLeftReceivedEventArgs> PlayerLeftReceived;
        
        public event System.EventHandler<PlayerGuessReceivedEventArgs> PlayerGuessReceived;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult IntTeTestat.GuessServiceReference.GuessService.BeginConntect(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginConntect(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void IntTeTestat.GuessServiceReference.GuessService.EndConntect(System.IAsyncResult result) {
            base.Channel.EndConntect(result);
        }
        
        private System.IAsyncResult OnBeginConntect(object[] inValues, System.AsyncCallback callback, object asyncState) {
            this.VerifyCallbackEvents();
            return ((IntTeTestat.GuessServiceReference.GuessService)(this)).BeginConntect(callback, asyncState);
        }
        
        private object[] OnEndConntect(System.IAsyncResult result) {
            ((IntTeTestat.GuessServiceReference.GuessService)(this)).EndConntect(result);
            return null;
        }
        
        private void OnConntectCompleted(object state) {
            if ((this.ConntectCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ConntectCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ConntectAsync() {
            this.ConntectAsync(null);
        }
        
        public void ConntectAsync(object userState) {
            if ((this.onBeginConntectDelegate == null)) {
                this.onBeginConntectDelegate = new BeginOperationDelegate(this.OnBeginConntect);
            }
            if ((this.onEndConntectDelegate == null)) {
                this.onEndConntectDelegate = new EndOperationDelegate(this.OnEndConntect);
            }
            if ((this.onConntectCompletedDelegate == null)) {
                this.onConntectCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnConntectCompleted);
            }
            base.InvokeAsync(this.onBeginConntectDelegate, null, this.onEndConntectDelegate, this.onConntectCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult IntTeTestat.GuessServiceReference.GuessService.BeginAddName(string name, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginAddName(name, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void IntTeTestat.GuessServiceReference.GuessService.EndAddName(System.IAsyncResult result) {
            base.Channel.EndAddName(result);
        }
        
        private System.IAsyncResult OnBeginAddName(object[] inValues, System.AsyncCallback callback, object asyncState) {
            this.VerifyCallbackEvents();
            string name = ((string)(inValues[0]));
            return ((IntTeTestat.GuessServiceReference.GuessService)(this)).BeginAddName(name, callback, asyncState);
        }
        
        private object[] OnEndAddName(System.IAsyncResult result) {
            ((IntTeTestat.GuessServiceReference.GuessService)(this)).EndAddName(result);
            return null;
        }
        
        private void OnAddNameCompleted(object state) {
            if ((this.AddNameCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.AddNameCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void AddNameAsync(string name) {
            this.AddNameAsync(name, null);
        }
        
        public void AddNameAsync(string name, object userState) {
            if ((this.onBeginAddNameDelegate == null)) {
                this.onBeginAddNameDelegate = new BeginOperationDelegate(this.OnBeginAddName);
            }
            if ((this.onEndAddNameDelegate == null)) {
                this.onEndAddNameDelegate = new EndOperationDelegate(this.OnEndAddName);
            }
            if ((this.onAddNameCompletedDelegate == null)) {
                this.onAddNameCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnAddNameCompleted);
            }
            base.InvokeAsync(this.onBeginAddNameDelegate, new object[] {
                        name}, this.onEndAddNameDelegate, this.onAddNameCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult IntTeTestat.GuessServiceReference.GuessService.BeginGuess(int value, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGuess(value, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void IntTeTestat.GuessServiceReference.GuessService.EndGuess(System.IAsyncResult result) {
            base.Channel.EndGuess(result);
        }
        
        private System.IAsyncResult OnBeginGuess(object[] inValues, System.AsyncCallback callback, object asyncState) {
            this.VerifyCallbackEvents();
            int value = ((int)(inValues[0]));
            return ((IntTeTestat.GuessServiceReference.GuessService)(this)).BeginGuess(value, callback, asyncState);
        }
        
        private object[] OnEndGuess(System.IAsyncResult result) {
            ((IntTeTestat.GuessServiceReference.GuessService)(this)).EndGuess(result);
            return null;
        }
        
        private void OnGuessCompleted(object state) {
            if ((this.GuessCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GuessCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GuessAsync(int value) {
            this.GuessAsync(value, null);
        }
        
        public void GuessAsync(int value, object userState) {
            if ((this.onBeginGuessDelegate == null)) {
                this.onBeginGuessDelegate = new BeginOperationDelegate(this.OnBeginGuess);
            }
            if ((this.onEndGuessDelegate == null)) {
                this.onEndGuessDelegate = new EndOperationDelegate(this.OnEndGuess);
            }
            if ((this.onGuessCompletedDelegate == null)) {
                this.onGuessCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGuessCompleted);
            }
            base.InvokeAsync(this.onBeginGuessDelegate, new object[] {
                        value}, this.onEndGuessDelegate, this.onGuessCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult IntTeTestat.GuessServiceReference.GuessService.BeginQuitConnect(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginQuitConnect(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void IntTeTestat.GuessServiceReference.GuessService.EndQuitConnect(System.IAsyncResult result) {
            base.Channel.EndQuitConnect(result);
        }
        
        private System.IAsyncResult OnBeginQuitConnect(object[] inValues, System.AsyncCallback callback, object asyncState) {
            this.VerifyCallbackEvents();
            return ((IntTeTestat.GuessServiceReference.GuessService)(this)).BeginQuitConnect(callback, asyncState);
        }
        
        private object[] OnEndQuitConnect(System.IAsyncResult result) {
            ((IntTeTestat.GuessServiceReference.GuessService)(this)).EndQuitConnect(result);
            return null;
        }
        
        private void OnQuitConnectCompleted(object state) {
            if ((this.QuitConnectCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.QuitConnectCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void QuitConnectAsync() {
            this.QuitConnectAsync(null);
        }
        
        public void QuitConnectAsync(object userState) {
            if ((this.onBeginQuitConnectDelegate == null)) {
                this.onBeginQuitConnectDelegate = new BeginOperationDelegate(this.OnBeginQuitConnect);
            }
            if ((this.onEndQuitConnectDelegate == null)) {
                this.onEndQuitConnectDelegate = new EndOperationDelegate(this.OnEndQuitConnect);
            }
            if ((this.onQuitConnectCompletedDelegate == null)) {
                this.onQuitConnectCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnQuitConnectCompleted);
            }
            base.InvokeAsync(this.onBeginQuitConnectDelegate, null, this.onEndQuitConnectDelegate, this.onQuitConnectCompletedDelegate, userState);
        }
        
        private void OnStartGameReceived(object state) {
            if ((this.StartGameReceived != null)) {
                object[] results = ((object[])(state));
                this.StartGameReceived(this, new StartGameReceivedEventArgs(results, null, false, null));
            }
        }
        
        private void OnGameOverReceived(object state) {
            if ((this.GameOverReceived != null)) {
                object[] results = ((object[])(state));
                this.GameOverReceived(this, new GameOverReceivedEventArgs(results, null, false, null));
            }
        }
        
        private void OnConnectCanceledReceived(object state) {
            if ((this.ConnectCanceledReceived != null)) {
                object[] results = ((object[])(state));
                this.ConnectCanceledReceived(this, new System.ComponentModel.AsyncCompletedEventArgs(null, false, null));
            }
        }
        
        private void OnPlayerLeftReceived(object state) {
            if ((this.PlayerLeftReceived != null)) {
                object[] results = ((object[])(state));
                this.PlayerLeftReceived(this, new PlayerLeftReceivedEventArgs(results, null, false, null));
            }
        }
        
        private void OnPlayerGuessReceived(object state) {
            if ((this.PlayerGuessReceived != null)) {
                object[] results = ((object[])(state));
                this.PlayerGuessReceived(this, new PlayerGuessReceivedEventArgs(results, null, false, null));
            }
        }
        
        private void VerifyCallbackEvents() {
            if (((this.useGeneratedCallback != true) 
                        && (((((this.StartGameReceived != null) 
                        || (this.GameOverReceived != null)) 
                        || (this.ConnectCanceledReceived != null)) 
                        || (this.PlayerLeftReceived != null)) 
                        || (this.PlayerGuessReceived != null)))) {
                throw new System.InvalidOperationException("Callback events cannot be used when the callback InstanceContext is specified. Pl" +
                        "ease choose between specifying the callback InstanceContext or subscribing to th" +
                        "e callback events.");
            }
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            this.VerifyCallbackEvents();
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override IntTeTestat.GuessServiceReference.GuessService CreateChannel() {
            return new GuessServiceClientChannel(this);
        }
        
        private class GuessServiceClientCallback : object, GuessServiceCallback {
            
            private GuessServiceClient proxy;
            
            public void Initialize(GuessServiceClient proxy) {
                this.proxy = proxy;
            }
            
            public void StartGame(System.Collections.ObjectModel.ObservableCollection<string> players, string playerName) {
                this.proxy.OnStartGameReceived(new object[] {
                            players,
                            playerName});
            }
            
            public void GameOver(bool victory, System.Collections.ObjectModel.ObservableCollection<IntTeTestat.GuessServiceReference.Guess> playedValues) {
                this.proxy.OnGameOverReceived(new object[] {
                            victory,
                            playedValues});
            }
            
            public void ConnectCanceled() {
                this.proxy.OnConnectCanceledReceived(new object[0]);
            }
            
            public void PlayerLeft(string name) {
                this.proxy.OnPlayerLeftReceived(new object[] {
                            name});
            }
            
            public void PlayerGuess(IntTeTestat.GuessServiceReference.Guess guess) {
                this.proxy.OnPlayerGuessReceived(new object[] {
                            guess});
            }
        }
        
        private class GuessServiceClientChannel : ChannelBase<IntTeTestat.GuessServiceReference.GuessService>, IntTeTestat.GuessServiceReference.GuessService {
            
            public GuessServiceClientChannel(System.ServiceModel.DuplexClientBase<IntTeTestat.GuessServiceReference.GuessService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginConntect(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("Conntect", _args, callback, asyncState);
                return _result;
            }
            
            public void EndConntect(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("Conntect", _args, result);
            }
            
            public System.IAsyncResult BeginAddName(string name, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = name;
                System.IAsyncResult _result = base.BeginInvoke("AddName", _args, callback, asyncState);
                return _result;
            }
            
            public void EndAddName(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("AddName", _args, result);
            }
            
            public System.IAsyncResult BeginGuess(int value, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = value;
                System.IAsyncResult _result = base.BeginInvoke("Guess", _args, callback, asyncState);
                return _result;
            }
            
            public void EndGuess(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("Guess", _args, result);
            }
            
            public System.IAsyncResult BeginQuitConnect(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("QuitConnect", _args, callback, asyncState);
                return _result;
            }
            
            public void EndQuitConnect(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("QuitConnect", _args, result);
            }
        }
    }
    
    public class StartGameReceivedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public StartGameReceivedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<string> players {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<string>)(this.results[0]));
            }
        }
        
        public string playerName {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    public class GameOverReceivedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GameOverReceivedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool victory {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
        
        public System.Collections.ObjectModel.ObservableCollection<IntTeTestat.GuessServiceReference.Guess> playedValues {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<IntTeTestat.GuessServiceReference.Guess>)(this.results[1]));
            }
        }
    }
    
    public class PlayerLeftReceivedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public PlayerLeftReceivedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string name {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    public class PlayerGuessReceivedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public PlayerGuessReceivedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public IntTeTestat.GuessServiceReference.Guess guess {
            get {
                base.RaiseExceptionIfNecessary();
                return ((IntTeTestat.GuessServiceReference.Guess)(this.results[0]));
            }
        }
    }
}
