import React, { Component } from 'react';
import {emojify} from 'react-emojione';

class ChatContent extends Component {
  render() {
    return (
      <div className="panel panel-default chat-content">
        <div className="panel-body">
          {this.props.messages.map((m, idx) => {
            return <div key={idx}>[{m.timestamp.toLocaleDateString()} {m.timestamp.toLocaleTimeString()}][{m.user}]: {emojify(m.message)}</div>
          })}
        </div>
      </div>
    );
  }
}

export default ChatContent;