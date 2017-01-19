'use strict'

var Work = React.createClass({
    handleButton: function(){
        var xhr;
        xhr= new XMLHttpRequest();
        console.log("asudkhiashd");
        xhr.open('post', this.props.submitUrl, true);
        xhr.onload = function () { };
        xhr.send();
    },

    render() {
        return (
            <div>
                <div className="work">WorkPage</div>
                <form onSubmit={this.handleButton}>
                    <input type="submit" value="Post" />
                </form>
            </div>
        );
    }
});
