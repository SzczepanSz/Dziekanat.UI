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

            dgvSubjects.CellEndEdit += DgvStudents_CellEndEdit;
            dgvSubjects.EditingControlShowing += dataGridView1_EditingControlShowing;
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
            dgvSubjects.MaximumSize = new Size() { Height = 370, Width = 580 };

            dgvStudents.Dock = DockStyle.Fill;
            dgvSubjects.Dock = DockStyle.Fill;

            dgvStudents.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvSubjects.EditMode = DataGridViewEditMode.EditProgrammatically;
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
        {   var dgv = sender as DataGridView;  
            if (dgv != null)
            {
                dgv.EditingControl.KeyPress -= EditingControl_KeyPress;
                dgv.EditingControl.KeyPress += EditingControl_KeyPress;
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
                case "dGVSubjects1":
                    e.Handled = !_controller.IsString(editingControl.Text + e.KeyChar);
                    break;
                case "dGVSubjects2":
                    e.Handled = !_controller.IsSemester(editingControl.Text + e.KeyChar);
                    break;
                case "dGVSubjects3":
                    e.Handled = !_controller.IsString(editingControl.Text + e.KeyChar);
                    break;              
                default:
                    break;
            }
        }


        private void btnStudents_Click(object sender, EventArgs e)
        {
            pnlSubjects.Visible = false;
            pnlStudents.Visible = true;
            dgvStudents.DataSource = _controller.GetAllStudents();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            pnlStudents.Visible = false;
            pnlSubjects.Visible = true;
            dgvSubjects.DataSource = _controller.GetAllSubjects();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            dgvStudents.DataSource = _controller.AddEmptyRowStudent();

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
            dgvSubjects.DataSource = _controller.AddEmptyRowSubject();

            SelectEtidedRow(dgvSubjects);
            BeginEdit(dgvSubjects, 1);
        }



        #endregion

        #region Auxiliry Methods

        private void SaveLastRow(DataGridView? dgv)
        {

            var selectedRow = dgv.Rows[dgv.Rows.Count - 1];
            if (dgv == dgvStudents)
            {
                _controller.AddStudent(new Student()
                {
                    Name = selectedRow.Cells[1].Value.ToString(),
                    SurName = selectedRow.Cells[2].Value.ToString(),
                    PESEL = Convert.ToInt64(selectedRow.Cells[3].Value)
                });
            }

            if (dgv == dgvSubjects)
            {
                _controller.AddSubject(new Subject()
                {
                    SubjectName = selectedRow.Cells[1].Value.ToString(),
                    Semester = Convert.ToInt32(selectedRow.Cells[2].Value),
                    Lecturer = selectedRow.Cells[3].Value.ToString(),
                });
            }

            dgv.Refresh();

        }

        private bool BeginEdit(DataGridView dgv, int column)
        {
            ;
            if (dgv.Columns.Count > column)
            {
                DataGridViewCell cell = dgv.Rows[dgv.Rows.Count - 1].Cells[column];

                SetEditableInfo(dgv, column);

                dgv.CurrentCell = cell;
                dgv.BeginEdit(true);
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
            dgv.Rows[dgv.Rows.Count - 1].Selected = true;
            dgv.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1;
        }
        #endregion

    
    }
}
    

//Oto aplikacja, kt�r� proponuj�, aby Pan zaimplementowa�, celem drugiego spotkania, aby�my mogli o niej porozmawia�.

 

//Program do rejestracji student�w. Ma mie� mo�liwo�� rejestracji studenta (imi�, nazwisko, pesel, data urodzenia).
//Ma mie� mo�liwo�� rejestracji przedmiotu (nazwa przedmiotu, semestr studi�w, imi� i nazwisko prowadz�cego). 
//    Ma by� mo�liwo�� rejestracji dla studenta przedmiotu, oraz rejestracji student�w dla wybranego przedmiotu. 
//    Program ma r�wnie� umo�liwia� wyszukiwanie student�w dla wskazanego przedmiotu i przedmiotu dla wskazanego studenta. 
//    Program powinien by� napisany z u�yciem MVVM (albo WinForms, albo Wpf). Maj� by� unit testy. 
//    Powinien u�ywa� EF.CORE w najnowszej wersji ze wsparciem tworzenia bazy przez migracj�. Oceniana b�dzie walidacja danych, uk�ad GUI,
//    nazewnictwo klas, komponent�w. Oceniana b�dzie modu�owo�� i separacja warstw. Oceniany b�dzie styl i komentarze.