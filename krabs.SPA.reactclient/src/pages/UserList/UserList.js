import React from 'react';
import {Button, makeStyles, Paper} from '@material-ui/core';
import axios from 'axios';

const useStyles = makeStyles(theme => ({}

));

export default function UserList() {
  const classes = useStyles();

  const onClickHandler = () => {
      axios.get("https://localhost:5011/api/UserManagement/List/list?q=10&p=1")
          .then(data => {
              console.log(data);
          });
  };

  return (
      <div style={{ minHeight: 400 }}>
          <Paper style={{ minHeight: 400 }}>
            <Button onClick={onClickHandler} variant="outlined">Get Users</Button>
          </Paper>
      </div>
  )
}
