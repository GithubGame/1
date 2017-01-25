import React, { Component } from 'react';

class RemoteUserDisplay extends Component {
  render() {
    return (
      <div className="panel panel-default your-talking-to-display">
        <div className="panel-body">
          <div>You're connected to <b>{this.props.userInfo.userName}</b></div>
          <div>He's trying to learn <b>{this.props.userInfo.learning}</b></div>
          <div>He is fluent in <b>{this.props.userInfo.canSpeak}</b></div>
        </div>
      </div>
    );
  }
}

export default RemoteUserDisplay;