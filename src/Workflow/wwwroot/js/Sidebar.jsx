var Sidebar = React.createClass({
    render() {
        return (
          <div className="sidebar">
              <ul>
                <li className="menu">
                  <a href="#" className="active">Departamentul de Matematică</a>
                  <ul>
                    <li className="subMenu"><a href="#">Laboratorul de Cercetare în Matematică Aplicată</a></li>
                  </ul>
                </li>
                <hr/>

                <li className="menu">
                  <a href="#">Departamentul de Informatică</a>
                  <ul>
                    <li className="subMenu">
                      <a href="#">Institutul de Informatică</a>
                    </li>

                    <li className="subMenu">
                      <a href="#">Laboratorul de Cercetare Științifică în Domeniul Informaticii</a>
                    </li>
                  </ul>
                </li>
                <hr/>

                <li className="menu">
                  <a href="#">Departamentul de Matematică Informatică (HU)</a>
                </li>
                <hr/>
              </ul>

            <ul>
              <li>
                <Link to="/reader" rel="">ReaderPage</Link>
              </li>
              <li>
                <Link to="/contributor" rel="">ContributorPage</Link>
              </li>
              <li>
                <Link to="/manager" rel="">ManagerPage</Link>
              </li>
              <li>
                <Link to="/admin" rel="">AdminPage</Link>
              </li>
            </ul>
          </div>
      );
    }
});

ReactDOM.render(
  <Sidebar url="/Home"/>,
  document.getElementById('content')
);