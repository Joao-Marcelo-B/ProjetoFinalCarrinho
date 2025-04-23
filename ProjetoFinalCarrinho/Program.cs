using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace ProjetoFinalCarrinho
{
    internal class Program
    {
        static float tx = 0.3f;
        static float ty = 0.3f;
        const float PI = 3.14f;

        static void Main(string[] args)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(1366, 768);
            Glut.glutCreateWindow("Carrinho");
            inicializa();
            Glut.glutDisplayFunc(desenha);
            Glut.glutSpecialFunc(TeclasEspeciais);
            Glut.glutMainLoop();
        }

        static void inicializa()
        {
            Gl.glClearColor(0, 0, 0, 0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, 1.0, 0.0, 1.0);
        }

        static void desenha()
        {
            fundo();
            pista();
            detalhesPista();
            desenhaCarrinho();
        }

        public static void TeclasEspeciais(int key, int x, int y)
        {
            MoverCarrinho(key);
            Glut.glutPostRedisplay();
        }

        static void MoverCarrinho(int key)
        {
            switch (key)
            {
                case Glut.GLUT_KEY_UP:
                    ty += 0.03f;
                    break;
                case Glut.GLUT_KEY_DOWN:
                    ty -= 0.03f;
                    break;
                case Glut.GLUT_KEY_LEFT:
                    tx -= 0.03f;
                    break;
                case Glut.GLUT_KEY_RIGHT:
                    tx += 0.03f;
                    break;
            }
        }

        static void fundo()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glColor3f(0.6f, 0.3f, 0.0f);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(0.0f, 0.0f);
            Gl.glVertex2f(0.0f, 1.0f);
            Gl.glVertex2f(1.0f, 1.0f);
            Gl.glVertex2f(1.0f, 0.0f);
            Gl.glEnd();

            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(0.2f, 0.2f);
            Gl.glVertex2f(0.2f, 0.7f);
            Gl.glVertex2f(0.8f, 0.7f);
            Gl.glVertex2f(0.8f, 0.2f);
            Gl.glEnd();

        }

        static void pista()
        {
            Gl.glColor3f(0.5f, 0.5f, 0.5f);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(0.05f, 0.1f);
            Gl.glVertex2f(0.05f, 0.3f);
            Gl.glVertex2f(0.95f, 0.3f);
            Gl.glVertex2f(0.95f, 0.1f);
            Gl.glEnd();


            Gl.glColor3f(0.5f, 0.5f, 0.5f);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(0.05f, 0.9f);
            Gl.glVertex2f(0.05f, 0.7f);
            Gl.glVertex2f(0.95f, 0.7f);
            Gl.glVertex2f(0.95f, 0.9f);
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(0.05f, 0.1f);
            Gl.glVertex2f(0.05f, 0.7f);
            Gl.glVertex2f(0.2f, 0.7f);
            Gl.glVertex2f(0.2f, 0.1f);
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(0.8f, 0.1f);
            Gl.glVertex2f(0.8f, 0.7f);
            Gl.glVertex2f(0.95f, 0.7f);
            Gl.glVertex2f(0.95f, 0.1f);
            Gl.glEnd();

        }

        static void detalhesPista()
        {
            Gl.glColor3f(1.0f, 1.0f, 1.0f);

            for (float i = 0.25f; i <= 0.85; i += 0.05f)
            {
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glVertex2f(i - 0.05f, 0.19f);
                Gl.glVertex2f(i - 0.05f, 0.2f);
                Gl.glVertex2f(i - 0.02f, 0.2f);
                Gl.glVertex2f(i - 0.02f, 0.19f);
                Gl.glEnd();

            }

            for (float i = 0.25f; i <= 0.85; i += 0.05f)
            {
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glVertex2f(i - 0.05f, 0.79f);
                Gl.glVertex2f(i - 0.05f, 0.8f);
                Gl.glVertex2f(i - 0.02f, 0.8f);
                Gl.glVertex2f(i - 0.02f, 0.79f);
                Gl.glEnd();

            }

            for (float i = 0.2f; i <= 0.75; i += 0.05f)
            {
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glVertex2f(0.87f, i);
                Gl.glVertex2f(0.87f, i + 0.05f);
                Gl.glVertex2f(0.875f, i + 0.05f);
                Gl.glVertex2f(0.875f, i);
                i += 0.05f;
                Gl.glEnd();

            }

            for (float i = 0.2f; i <= 0.75; i += 0.05f)
            {
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glVertex2f(0.12f, i);
                Gl.glVertex2f(0.12f, i + 0.05f);
                Gl.glVertex2f(0.125f, i + 0.05f);
                Gl.glVertex2f(0.125f, i);
                i += 0.05f;
                Gl.glEnd();

            }
        }

        static void desenhaCarrinho()
        {
            float raio, x, y, pontos;
            raio = 0.017f;
            pontos = (2 * PI) / 16;

            Gl.glPushMatrix();
            Gl.glTranslatef(tx, ty, 0.0f);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex2f(-0.05f, -0.05f);
            Gl.glVertex2f(0.0f, -0.05f);
            Gl.glVertex2f(0.0f, 0.0f);
            Gl.glVertex2f(-0.05f, 0.0f);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex2f(-0.02f, -0.03f);
            Gl.glVertex2f(0.0f, -0.03f);
            Gl.glVertex2f(0.0f, 0.0f);
            Gl.glVertex2f(-0.02f, 0.0f);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glColor3f(0f, 0f, 0f);
            Gl.glLineWidth(1);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            for (float angulo = 0.0f; angulo <= 2 * PI; angulo += pontos)
            {
                x = (float)(raio * Math.Cos(angulo) + 0.151);
                y = (float)(raio * Math.Sin(angulo) + 0.15);
                Gl.glVertex2f(x - 0.2f, y - 0.2f);
            }
            Gl.glEnd();

            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glColor3f(0f, 0f, 0f);
            Gl.glLineWidth(1);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            for (float angulo = 0.0f; angulo <= 2 * PI; angulo += pontos)
            {
                x = (float)(raio * Math.Cos(angulo) + 0.195);
                y = (float)(raio * Math.Sin(angulo) + 0.15);
                Gl.glVertex2f(x - 0.2f, y - 0.2f);
            }
            Gl.glEnd();

            Gl.glPopMatrix();
        }
    }
}
