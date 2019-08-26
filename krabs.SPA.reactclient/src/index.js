import React from 'react';
import ReactDOM from 'react-dom';
import 'toastr/build/toastr.min.css';
import * as serviceWorker from './serviceWorker';
import { BrowserRouter as Router } from "react-router-dom";
import CssBaseline from '@material-ui/core/CssBaseline';
import Routes from './Routes';

class T extends React.Component {
  render() {
    return (
      <div>
        <CssBaseline />
        <Router>
          <Routes />
        </Router>
      </div>
    )
  }
}

ReactDOM.render(<T />, document.getElementById('root'));
serviceWorker.unregister();
