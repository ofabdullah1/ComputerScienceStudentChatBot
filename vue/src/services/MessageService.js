import axios from 'axios'

const path = '/message';

export default{

    sendMessage(message){
        return axios.post(path, message);
    }

}