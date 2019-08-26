import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Drawer from '@material-ui/core/Drawer';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import InboxIcon from '@material-ui/icons/MoveToInbox';
import { Link } from 'react-router-dom';

function ListItemLink(props) {
  return <ListItem button component={Link} {...props} />;
}

const drawerWidth = 240;

const useStyles = makeStyles(theme => ({
  drawer: {
    width: drawerWidth,
    flexShrink: 0,
  },
  drawerPaper: {
    width: drawerWidth,
    zIndex: 99
  },
  toolbar: theme.mixins.toolbar,
  content: {
    marginLeft: drawerWidth,
    flexGrow: 1,
    backgroundColor: theme.palette.background.default,
    padding: theme.spacing(3),
  },
}));

export default function SideBar(props) {
  const [selectedIndex, setSelectedIndex] = React.useState(0);
  const classes = useStyles();
  return (
    <div className={classes.root}>
      <Drawer
        className={classes.drawer}
        variant="permanent"
        classes={{
          paper: classes.drawerPaper,
        }}
        anchor="left"
      >
        <div className={classes.toolbar} />
        <List>
          <ListItemLink
            selected={selectedIndex === 0}
            onClick={() => setSelectedIndex(0)}
            to="/"
          >
            <ListItemIcon><InboxIcon /></ListItemIcon>
            <ListItemText primary="Home" />
          </ListItemLink>
          <ListItemLink
            selected={selectedIndex === 1}
            onClick={() => setSelectedIndex(1)}
            to="/user-list"
          >
            <ListItemIcon><InboxIcon /></ListItemIcon>
            <ListItemText primary="User List" />
          </ListItemLink>
        </List>
      </Drawer>
      <main className={classes.content}>
        <div className={classes.toolbar} />
        {props.children}
      </main>
    </div>
  );
}
