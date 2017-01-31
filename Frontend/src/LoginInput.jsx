import React, { Component } from 'react';

class LoginInput extends Component {
  constructor(props) {
    super(props);

    this.state = {
      username: ''
    };

    this.handleLogin = this.handleLogin.bind(this);
    this.handleKeyPress = this.handleKeyPress.bind(this);
    this.handleUsernameChange = this.handleUsernameChange.bind(this);
  }

  handleLogin() {
    this.props.setLogedIn(this.state.username) ;
  }

  handleKeyPress(ev) {
    if (ev.key === 'Enter') {
      this.handleLogin();
    }
  }

  handleUsernameChange(ev) {
    this.setState({
      username: ev.target.value
    });
  }

  render() {

    return (
      <div className="panel panel-default content">
        <div className="panel-header">Please log in</div>
        <div className="panel-body content-body">
          <div className="input-group">
            <input type="text" className="form-control" aria-label="login input box" onChange={this.handleUsernameChange} onKeyPress={this.handleKeyPress} />
            <div className="input-group-btn">
              <button type="button" className="btn btn-success" onClick={this.handleLogin}><i className="glyphicon glyphicon-comment" /></button>
            </div>
          </div>
        </div>
      </div>
    );
  }

}

export default LoginInput;
