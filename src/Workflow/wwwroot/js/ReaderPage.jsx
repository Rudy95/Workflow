var Reader = React.createClass({
    render() {
        var documents = [
          {"id": 1, "title": "Title #1", "authorUsername": "author_username1"},
          {"id": 2, "title": "Title #2", "authorUsername": "author_username2"},
          {"id": 3, "title": "Title #3", "authorUsername": "author_username3"},
          {"id": 4, "title": "Title #4", "authorUsername": "author_username4"},
          {"id": 5, "title": "Title #5", "authorUsername": "author_username5"},
        ];

        return(
          <div className="reader">
            <DocumentTable documents={documents}/>
          </div>
        );
    }
});

ReactDOM.render(
  <Login url="/Home"/>,
  document.getElementById('content')
);