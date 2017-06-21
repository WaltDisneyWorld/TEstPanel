import React from 'react';
import ReactDOM from 'react-dom';
import {Route, HashRouter} from 'react-router-dom'
import injectTapEventPlugin from 'react-tap-event-plugin';


// Needed for onTouchTap
// http://stackoverflow.com/a/34015469/988941
injectTapEventPlugin();

class App extends React.Component {
    render() {
        return (
            <div>Hello world!</div>
        )
    }
}

ReactDOM.render((
    <HashRouter>
        <div>
            <Route exact path="/" component={App}/>
        </div>
    </HashRouter>
), document.getElementById('root'));