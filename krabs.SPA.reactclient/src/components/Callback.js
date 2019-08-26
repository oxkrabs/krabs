
import * as React from 'react'

class Callback extends React.Component {
  componentDidMount() {
    const { onSuccess, onError, userManager } = this.props;

    const um = userManager;
    um.signinRedirectCallback()
      .then(user => {
        if (onSuccess) {
          onSuccess(user)
        }
      })
      .catch(err => {
        if (onError) {
          onError(err)
        }
      })
  }
  render() {
    return this.props.children || null
  }
}

export default Callback
