
pipeline {
    agent any

    environment {
        APP_IMAGE = 'smartmall-api:1.0'
        CONTAINER_NAME = 'smartmall-api-cicd'
        SSH_HOST = 'HP@host.docker.internal'
        SSH_KEY = '/var/jenkins_home/.ssh/id_ed25519'
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Docker Build') {
            steps {
                sh 'docker build -t $APP_IMAGE .'
            }
        }

        stage('Transfer Image') {
            steps {
                sh '''
                    docker save $APP_IMAGE | ssh -i $SSH_KEY \
                    -o StrictHostKeyChecking=no $SSH_HOST "docker load"
                '''
            }
        }

        stage('Deploy') {
            steps {
                sh '''
                    ssh -i $SSH_KEY -o StrictHostKeyChecking=no $SSH_HOST \
                    "docker rm -f $CONTAINER_NAME 2>/dev/null || true; docker run -d --restart unless-stopped --name $CONTAINER_NAME -p 7001:8080 $APP_IMAGE"
                '''
            }
        }
    }
}
