import React, {useEffect}  from 'react';
import api from '../../services/api';

const Home = () => {

    useEffect(() => {
        api.get('items').then(response => {
            console.log(response.data);
        });
    }, []);

    return (
        <div id="test">
            <h1>Hello World</h1>
        </div>
    );

}

export default Home;