import React, {useEffect, useState}  from 'react';
import api from '../../services/api';
import Container from '@material-ui/core/Container';
import Grid from '@material-ui/core/Grid';
import Card from '@material-ui/core/Card';
import CardMedia from '@material-ui/core/CardMedia';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';

interface Playlist {
    id: string;
    name: string;
    urls: string[];
}

const Home = () => {
    const [playlists, setPlaylists] = useState<Playlist[]>([]);

    useEffect(() => {
        api.get('getAll').then(response => {
            setPlaylists(response.data);
        });
    }, []);

    return (
        <Container className="container" maxWidth="md">
            <Grid container spacing={4}>
                {playlists.map((item: Playlist) => (
                    <Grid item key={item.id} xs={12} sm={6} md={4}>
                        <Card >
                            <CardMedia
                             image="https://source.unsplash.com/random"
                             title="Image title" />
                             <CardContent>
                                <Typography gutterBottom variant="h5" component="h2">
                                    {item.name}
                                </Typography>

                                <Typography>
                                    This is a media card. You can use this section to describe the content.
                                </Typography>
                            </CardContent>
                        </Card>
                    </Grid>
                ))}
            </Grid>
        </Container>
    );

}

export default Home;