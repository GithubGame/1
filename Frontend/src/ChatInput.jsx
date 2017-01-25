import React, { Component } from 'react';

class ChatInput extends Component {
  constructor(props) {
    super(props);

    this.state = {
      chatValue: ''
    }

    this.handleChatValueChange = this.handleChatValueChange.bind(this);
    this.handleSubmitChat = this.handleSubmitChat.bind(this);
    this.handleKeyPress = this.handleKeyPress.bind(this);
  }

  handleChatValueChange(ev) {
    this.setState({
      chatValue: ev.target.value
    });
  }

  handleSubmitChat() {
    this.props.addMessage(this.state.chatValue, 'You', new Date())

    this.setState({
      chatValue: ''
    })
  }

  handleKeyPress(ev) {
    if (ev.key === 'Enter') {
      this.handleSubmitChat();
    }
  }

  render() {
    return (
      <div className="input-group">
        <input type="text" className="form-control" aria-label="Chat input box" value={this.state.chatValue} onChange={this.handleChatValueChange} onKeyPress={this.handleKeyPress}/>
        <div className="input-group-btn">
          <button type="button" className="btn btn-success" onClick={this.handleSubmitChat}><i className="glyphicon glyphicon-comment" /></button>
        </div>
      </div>
    );
  }
}

export default ChatInput;