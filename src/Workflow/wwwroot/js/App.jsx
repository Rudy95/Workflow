var App = React.createClass({
    render() {
        return (
          <Router history={browserHistory}>
        <Route path="/" component={LoginPage}/>

        <Route path="/login" component={LoginPage}>
          <Route path="/reader" component={ReaderPage}/>
          <Route path="/contributor" component={ContributorPage}/>
          <Route path="/manager" component={ManagerPage}/>
          <Route path="/admin" component={AdminPage}/>
        </Route>
      </Router>
    );
}
});

const Container = (props) => <div>
  <Header/>
  <Sidebar/>
  {props.children}
</div>;

ReactDOM.render(
  <Login url="/Home"/>,
  document.getElementById('content')
);