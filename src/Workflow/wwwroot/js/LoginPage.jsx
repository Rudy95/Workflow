    
var Login = React.createClass({
    
    render(){
        return (
            <div className="wrapper">
                <div className="login">
                    <form>
                        <div className="flex-box">
                            <div className="logo-img">
                                <img src="http://i.imgur.com/6FHIXpn.png"/>
                            </div>

                            <div>User Login</div>

                            <div className="container">
                                <input type="text" placeholder="Enter your username"/>
                                <input type="password" placeholder="Enter your password"/>
                            </div>

                            <div className="container">
                                <input className="btn" type="submit" value="POST" />
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        );
    }
});


   