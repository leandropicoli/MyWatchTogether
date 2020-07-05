import React, {useEffect, useState}  from 'react';
import api from '../../services/api';
import { Theme, createStyles, makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import GridList from '@material-ui/core/GridList';
import GridListTile from '@material-ui/core/GridListTile';
import GridListTileBar from '@material-ui/core/GridListTileBar';
import ListSubheader from '@material-ui/core/ListSubheader';
import IconButton from '@material-ui/core/IconButton';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import Card from '@material-ui/core/Card';
import CardMedia from '@material-ui/core/CardMedia';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';

import './styles.css';

interface Playlist {
    id: string;
    name: string;
    urls: string[];
}

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
      flexGrow: 1,
      padding: 50
    },
    paper: {
      padding: theme.spacing(2),
      textAlign: 'center',
      color: theme.palette.text.secondary,
    },
    item: {
      cursor: 'pointer',
    },
    image: {
        height: 0,
        paddingTop: '56.25%'
    },
  }),
);


const Home = () => {
    const [playlists, setPlaylists] = useState<Playlist[]>([]);

    useEffect(() => {
        api.get('getAll').then(response => {
            setPlaylists(response.data);
        });
    }, []);

    const classes = useStyles();

    return (
        <div className={classes.root}>
            <Grid container spacing={10}>
                {playlists.map((playlist: Playlist) => (
                    <Grid item xs={4}>
                        <Card className={classes.item}>
                            <CardMedia
                                className={classes.image}
                                image="https://source.unsplash.com/random"
                                title={playlist.name}
                            />
                            <CardContent>
                                <Typography variant="body2" color="textSecondary" component="p">
                                    {playlist.name}
                                </Typography>
                            </CardContent>
                        </Card>
                    </Grid>
                ))}
            </Grid>
        </div>
    );

}

export default Home;