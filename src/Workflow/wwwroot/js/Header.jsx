var Header = React.createClass({
    render() {
        return (
          <div className="header">
            <div className="logo">
              <Link to="/login">insert name here</Link>
            </div>
            <div className="logOut">
              <Link to="/">log out</Link>
            </div>
          </div>
    );
    }
});

ReactDOM.render(
  <Login url="/Home"/>,
  document.getElementById('content')
);