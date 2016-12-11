
var Login = React.createClass({

    getInitialState: function(){
        return { email:'', password:'' }
    },
    resetInitialState: function () {
        this.setState({
            email: '', password: ''
        });
    },
    handleEmail:function(e){
        this.setState({email: e.target.value});
    },
    handlePassword:function(e){
        this.setState({password: e.target.value});
    },
    handleSubmit: function(e){
        e.preventDefault();

        var email = this.state.email.trim();
        var password = this.state.password.trim();
        if (!email || !password)
            return;

        var valid = true;

        //this.state.Fields.forEach(function (field) {

        //});

        if (valid) {
            var data = {
                Email: this.state.email,
                Password: this.state.password
            }

            //$.ajax({
            //    type: "POST",
            //    url: this.props.urlPost,
            //    data: data,
            //    succes: function (data) {
            //        //this.state.resetInitialState();
            //    }.bind(this),
            //    error: function (e) {
            //        console.log("Error, try again"+e);
            //    }

            //});
        }

        var data = new FormData();
        data.append('Email', email);
        data.append('Password', password);

        var xhr = new XMLHttpRequest();
        xhr.open('post', this.props.urlPost, true);
        xhr.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
        xhr.send(data);

        this.setState({ email: '', password: '' });

    },

    render:function() {
                return (
                    <div className="wrapper">
                        <div className="login">
                            <form onSubmit={this.handleSubmit}>
                                <div className="flex-box">

                                    <div className="logo">
                                        <img src="http://i.imgur.com/6FHIXpn.png" />
                                    </div>

                                    <div>User Login</div>

                                    <div className="container">
                                        <input type="text" placeholder="Email" 
                                               value={this.state.email}
                                               onChange={this.handleEmail}/>
                                        <input type="password" placeholder="Password" 
                                               value={this.state.password}
                                               onChange={this.handlePassword}/>
                                    </div>

                                    <div className="container">
                                        <button type="submit" className="button" value="Post"> LOGIN</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                );
            }
});

ReactDOM.render(
  <Login urlPost="/Account/Login"/>,
  document.getElementById('content')
);

