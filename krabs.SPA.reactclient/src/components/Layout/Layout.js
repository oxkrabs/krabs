import React from 'react';
import ApplicationTopBar from "../ApplicationTopBar";
import Sidebar from "../Sidebar";

export default class Layout extends React.Component {
  render() {
    return (
      <div>
        <ApplicationTopBar/>
        <Sidebar>
          {this.props.children}
        </Sidebar>
      </div>
    )
  }
}

