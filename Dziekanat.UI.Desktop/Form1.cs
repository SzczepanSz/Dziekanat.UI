//using Dziekanat.DAL;
//using Dziekanat.DAL.Models;
using Dziekanat.Controller;
using Dziekanat.DAL;
using Dziekanat.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Dziekanat.UI.Desktop
{
    public partial class BaseForm : Form
    {
        #region Properties
        delegate void SetColumnIndex(int i);


        private Form popForm;
        private DziekanatController _controller;
        //  private Dictionary<string, int> _columnInfo;
        private string _columnInfo;

        #endregion

        #region Init
        public BaseForm()
        {
            InitializeComponent();
            _controller = new DziekanatController();

            LayoutInit();
            EvntsInit();
            btnStudents_Click(this, null);
     //       dgvStudents.MultiSelect = false;
        }

        private void EvntsInit()
        {
            dgvStudents.CellEndEdit += DgvStudents_CellEndEdit;
            dgvStudents.EditingControlShowing += dataGridView1_EditingControlShowing;
        }

        private void LayoutInit()
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            pnlStudents.Visible = false;
            pnlSubjects.Visible = false;

            pnlStudents.Dock = DockStyle.Fill;
            pnlSubjects.Dock = DockStyle.Fill;



            dgvStudents.MaximumSize = new Size() { Height = 370, Width = 580 };
            dGVSubjects.MaximumSize = new Size() { Height = 370, Width = 580 };

            dgvStudents.Dock = DockStyle.Fill;
            dGVSubjects.Dock = DockStyle.Fill;

            dgvStudents.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVSubjects.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


        #endregion

        #region Events
        private void DgvStudents_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            var dgvEdited = sender as DataGridView;

            try
            {
                if (dgvEdited != null && dgvEdited.Columns.Count - 1 > e.ColumnIndex)
                {
                    BeginEdit(dgvEdited, e.ColumnIndex + 1);
                }
                else if (dgvEdited != null)
                {
                    SaveLastRow(sender as DataGridView);

                }
            }
            catch (Exception)
            {
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (sender != null)
            {
                dgvStudents.EditingControl.KeyPress -= EditingControl_KeyPress;
                dgvStudents.EditingControl.KeyPress += EditingControl_KeyPress;
            }

        }

        private void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control editingControl = (Control)sender;
            switch (_columnInfo)
            {
                case "dgvStudents1":
                    e.Handled = !_controller.IsString(editingControl.Text + e.KeyChar);
                    break;
                case "dgvStudents2":
                    e.Handled = !_controller.IsString(editingControl.Text + e.KeyChar);
                    break;
                case "dgvStudents3":
                    e.Handled = !_controller.IsPESEL(editingControl.Text + e.KeyChar);
                    break;
                case "dgvSubjects1":
                    e.Handled = !_controller.IsString(editingControl.Text + e.KeyChar);
                    break;
                case "dgvSubjects2":
                    e.Handled = !_controller.IsSemester(editingControl.Text + e.KeyChar);
                    break;
                case "dgvSubjects3":
                    e.Handled = !_controller.IsPESEL(editingControl.Text + e.KeyChar);
                    break;
                case "dgvSubjects4":
                    e.Handled = !_controller.IsString(editingControl.Text + e.KeyChar);
                    break;
                default:
                    break;
            }
        }


        private void btnStudents_Click(object sender, EventArgs e)
        {
            pnlStudents.Visible = true;
            pnlSubjects.Visible = false;

            dgvStudents.DataSource = _controller.GetAllStudents();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            //   PnlVisibility();
            pnlSubjects.Visible = true;
            pnlStudents.Visible = false;

            dGVSubjects.DataSource = _controller.GetAllSubjects();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            dgvStudents.DataSource = _controller.AddEmptyRow();

            SelectEtidedRow(dgvStudents);
            BeginEdit(dgvStudents, 1);
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {

            Student rowSelected = dgvStudents.CurrentRow.DataBoundItem as Student;
            _controller.DeleteStudent(rowSelected.IdStudent);
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {

        }



        #endregion

        #region Auxiliry Methods

        private void SaveLastRow(DataGridView? dgv)
        {

            var selectedRow = dgv.Rows[dgv.Rows.Count - 1];

            _controller.AddStudent(new Student()
            {
                Name = selectedRow.Cells[1].Value.ToString(),
                SurName = selectedRow.Cells[2].Value.ToString(),
                PESEL = Convert.ToInt64(selectedRow.Cells[3].Value)
            });
            dgv.Refresh();

        }

        private bool BeginEdit(DataGridView dgv, int column)
        {
            ;
            if (dgv.Columns.Count > column)
            {
                DataGridViewCell cell = dgvStudents.Rows[dgv.Rows.Count - 1].Cells[column];

                SetEditableInfo(dgv, column);

                dgvStudents.CurrentCell = cell;
                dgvStudents.BeginEdit(true);
                return false;
            }
            return true;
        }

        private void SetEditableInfo(DataGridView dgv, int column)
        {
            _columnInfo = dgv.Name + column.ToString();
        }

        private void SelectEtidedRow(DataGridView dgv)
        {
            dgv.ClearSelection();
            dgvStudents.Rows[dgv.Rows.Count - 1].Selected = true;
            dgvStudents.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1;
        }
        #endregion

    
    }
}
    

//Oto aplikacja, któr¹ proponujê, aby Pan zaimplementowa³, celem drugiego spotkania, abyœmy mogli o niej porozmawiaæ.

 

//Program do rejestracji studentów. Ma mieæ mo¿liwoœæ rejestracji studenta (imiê, nazwisko, pesel, data urodzenia).
//Ma mieæ mo¿liwoœæ rejestracji przedmiotu (nazwa przedmiotu, semestr studiów, imiê i nazwisko prowadz¹cego). 
//    Ma byæ mo¿liwoœæ rejestracji dla studenta przedmiotu, oraz rejestracji studentów dla wybranego przedmiotu. 
//    Program ma równie¿ umo¿liwiaæ wyszukiwanie studentów dla wskazanego przedmiotu i przedmiotu dla wskazanego studenta. 
//    Program powinien byæ napisany z u¿yciem MVVM (albo WinForms, albo Wpf). Maj¹ byæ unit testy. 
//    Powinien u¿ywaæ EF.CORE w najnowszej wersji ze wsparciem tworzenia bazy przez migracjê. Oceniana bêdzie walidacja danych, uk³ad GUI,
//    nazewnictwo klas, komponentów. Oceniana bêdzie modu³owoœæ i separacja warstw. Oceniany bêdzie styl i komentarze.