'use strict'

var Work = React.createClass({

    getInitialState() {
        return { keywords: '', abstract: '', document: '' };
    },

    handleKeywords(e) {
        this.setState({ keywords: e.target.value });
    },

    handleAbstract(e) {
        this.setState({ abstract: e.target.value });
    },
    
    render() {
        return (
            <div>
                <div className="work">WorkPage</div>
                {this.props.initialData}
                {this.props.url}
                {this.props.name}


            </div>
        );
    }
});
