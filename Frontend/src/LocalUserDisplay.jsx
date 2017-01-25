import React, { Component } from 'react';

class RemoteUserDisplay extends Component {
  render() {
    return (
      <div className="panel panel-default you-display">
        <div className="panel-body">
          <div>Hi there <b>{this.props.userInfo.userName}</b></div>
          <div>I see today you're trying to learn <b>{this.props.userInfo.learning}</b></div>
          <div>You've told us you're fluent in <b>{this.props.userInfo.canSpeak}</b></div>
        </div>
      </div>
    );
  }
}

export default RemoteUserDisplay;